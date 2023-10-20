using KamchatkaTravel.EntityFrameworkCore.EntityFrameworkCore;
using KamchatkaTravel.Identity.EntityFrameworkCore;
using KamchatkaTravel.Identity.Models;
using KamchatkaTravel.Web.Tests.DbContexts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Web.Tests.Tests.Base
{
    public class BaseIdentityRepositoryTest : IDisposable
    {
        protected readonly KamchatkaTravelIdentityDbContext context;
        protected readonly UserManager<IdentityPerson> userManager;
        protected readonly RoleManager<IdentityRole> roleManager;
        public BaseIdentityRepositoryTest()
        {
            context = IdentityDbContextFactory.Create();
            userManager = new UserManager<IdentityPerson>(null, null, null, null, null, null, null, null, null);
            roleManager = new RoleManager<IdentityRole>(null, null, null, null, null);

        }
        public void Dispose()
        {
            IdentityDbContextFactory.Destroy(context);
        }
    }
}
