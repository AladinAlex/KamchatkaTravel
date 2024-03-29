﻿using KamchatkaTravel.Application.Contracts.Common;
using KamchatkaTravel.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.Interfaces
{
    public interface IIdentityService
    {
        Task<ServiceResponse> AddRole(string name, string NormalizedName = null);
        Task<ServiceResponse> AddUserRole(IdentityPerson user, string role);
        Task<ServiceResponse> AddUser(string Name, string username, string password, string Surname = null, string Comment = null, string Email = null);
        Task<IdentityPerson?> GetUserByLogin(string username);
        Task UpdateTelegramInfo(int Id, int Chat_Id, bool isActive);
        Task CreateTelegramInfo(int Chat_Id, bool isActive, IdentityPerson identityPerson);
    }
}
