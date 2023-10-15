using KamchatkaTravel.EntityFrameworkCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Web.Tests
{
    public abstract class BaseTest : IDisposable
    {
        protected readonly KamchatkaTravelDbContext context;
        public BaseTest()
        {
            context = DbContextFactory.Create();

        }
        public void Dispose()
        {
            DbContextFactory.Destroy(context);
        }
    }
}
