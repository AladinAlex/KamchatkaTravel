using KamchatkaTravel.Identity.Common;
using KamchatkaTravel.Identity.EntityFrameworkCore;
using KamchatkaTravel.Identity.Interfaces;
using KamchatkaTravel.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Identity.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        readonly UserManager<IdentityPerson> _userManager;
        readonly RoleManager<IdentityRole> _roleManager;
        readonly KamchatkaTravelIdentityDbContext _context;
        public IdentityRepository(UserManager<IdentityPerson> userManager, RoleManager<IdentityRole> roleManager, KamchatkaTravelIdentityDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<IdentityResponse> AddRole(string name, string NormalizedName = null)
        {
            if (string.IsNullOrEmpty(name))
                return new IdentityResponse() { Status = ResponseStatus.Error, Error = "Название роли пустое." };
            var role = new IdentityRole()
            {
                Name = name, // admin
                NormalizedName = string.IsNullOrEmpty(NormalizedName) ? name : NormalizedName, // администратор
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            };
            var result = await _roleManager.CreateAsync(role);
            return Helpers.BaseResponse(result, "AddRole");
        }

        public async Task<IdentityResponse> AddUserRole(IdentityPerson user, string role)
        {
            if (user == null || string.IsNullOrEmpty(role))
                return new IdentityResponse() { Status = ResponseStatus.Error, Error = "Пользователь и роль не должны быть пустыми!" };

            var result = await _userManager.AddToRoleAsync(user, role);
            return Helpers.BaseResponse(result, "AddUserRole");
        }

        public async Task<IdentityResponse> AddUser(string Name, string login, string password, string Surname = null, string Comment = null, string Email = null)
        {
            var user = new IdentityPerson()
            {
                Name = Name,
                UserName = login,
                Surname = Surname,
                Comment = Comment,
                Email = Email
            };
            var result = await _userManager.CreateAsync(user, password);
            return Helpers.BaseResponse(result, "AddUser");
        }


        public async Task<IdentityPerson?> GetUserByLogin(string username)
        {
            //FindByNameAsync переопредлен в IdentityPersonStore
            var result = await _userManager.FindByNameAsync(username);
            return result;
        }

        public async Task UpdateTelegramInfo(int Id, int Chat_Id, bool isActive)
        {
            var entity = await _context.PersonTelegrams.FirstAsync(x => x.Id == Id);
            entity.Chat_Id = Chat_Id;
            entity.IsActive = isActive;
            _context.PersonTelegrams.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task CreateTelegramInfo(int Chat_Id, bool isActive, IdentityPerson identityPerson)
        { 
            var entity = new PersonTelegram()
            {
                Chat_Id = Chat_Id,
                IsActive = isActive,
                Person = identityPerson
            };
            await _context.PersonTelegrams.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<int>?> GetTelegramChatId(bool? isActive = true)
        {
            var result = await _context.PersonTelegrams.Where(x => x.IsActive && x.Chat_Id.HasValue).Select(x => x.Chat_Id.Value).ToListAsync();
            return result;
        }
    }
}
