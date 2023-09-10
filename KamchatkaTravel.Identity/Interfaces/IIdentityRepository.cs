using KamchatkaTravel.Identity.Models;
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
    }
}
