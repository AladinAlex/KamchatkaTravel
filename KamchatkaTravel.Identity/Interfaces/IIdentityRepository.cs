﻿using KamchatkaTravel.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Identity.Interfaces
{
    public interface IIdentityRepository
    {
        Task<IdentityResponse> AddRole(string name, string NormalizedName = null);
        Task<IdentityResponse> AddUserRole(IdentityPerson user, string role);
        Task<IdentityResponse> AddUser(string Name, string login, string password, string Surname = null, string Comment = null, string Email = null);
        Task<IdentityPerson?> GetUserByLogin(string username);
        Task UpdateTelegramInfo(int Id, int Chat_Id, bool isActive);
        Task CreateTelegramInfo(int Chat_Id, bool isActive, IdentityPerson identityPerson);

        Task<List<int>?> GetTelegramChatId(bool? isActive = true);
    }
}
