using KamchatkaTravel.EntityFrameworkCore.EntityFrameworkCore;

namespace KamchatkaTravel.Web.Tests.Tests.Base
{
    public abstract class BaseRepositoryTest : IDisposable
    {
        protected readonly KamchatkaTravelDbContext context;
        public BaseRepositoryTest()
        {
            context = DbContextFactory.Create();

        }
        public void Dispose()
        {
            DbContextFactory.Destroy(context);
        }
    }
}
