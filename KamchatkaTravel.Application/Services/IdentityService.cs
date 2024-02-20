using AutoMapper;
using KamchatkaTravel.Application.Contracts.Common;
using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Identity.Interfaces;
using KamchatkaTravel.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KamchatkaTravel.Application.Services
{
    public class IdentityService : IIdentityService
    {
        readonly IIdentityRepository _identityRepository;
        readonly IMapper _mapper;
        public IdentityService(IIdentityRepository identityRepository, IMapper mapper)
        {
            _identityRepository = identityRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> AddRole(string name, string NormalizedName = null)
        {
            var result = await _identityRepository.AddRole(name, NormalizedName);
            return _mapper.Map<ServiceResponse>(result);
        }

        public async Task<ServiceResponse> AddUserRole(IdentityPerson user, string role)
        {
            var result = await _identityRepository.AddUserRole(user, role);
            return _mapper.Map<ServiceResponse>(result);
        }

        public async Task<ServiceResponse> AddUser(string Name, string username, string password, string Surname = null, string Comment = null, string Email = null)
        {
            var result = await _identityRepository.AddUser(Name, username, password, Surname, Comment, Email);
            return _mapper.Map<ServiceResponse>(result);
        }

        public async Task<IdentityPerson?> GetUserByLogin(string username)
        {
            var result = await _identityRepository.GetUserByLogin(username);
            return result;
        }

        public async Task UpdateTelegramInfo(int Id, int Chat_Id, bool isActive)
        {
            await _identityRepository.UpdateTelegramInfo(Id, Chat_Id, isActive);
        }

        public async Task CreateTelegramInfo(int Chat_Id, bool isActive, IdentityPerson identityPerson)
        {
            await _identityRepository.CreateTelegramInfo(Chat_Id, isActive, identityPerson);
        }

    }
}
