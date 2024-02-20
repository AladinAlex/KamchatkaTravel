using KamchatkaTravel.EntityFrameworkCore.EntityFrameworkCore;
using KamchatkaTravel.Identity.EntityFrameworkCore;
using KamchatkaTravel.Web.Tests.DbContexts;

namespace KamchatkaTravel.Web.Tests.Tests.Base
{
    public abstract class BaseRepositoryTest : IDisposable
    {
        protected readonly KamchatkaTravelDbContext context;
        protected readonly KamchatkaTravelIdentityDbContext identityContext;
        public BaseRepositoryTest()
        {
            context = DbContextFactory.Create();
            identityContext = IdentityDbContextFactory.Create();

        }
        public void Dispose()
        {
            DbContextFactory.Destroy(context);
            IdentityDbContextFactory.Destroy(identityContext);
        }
    }
}
