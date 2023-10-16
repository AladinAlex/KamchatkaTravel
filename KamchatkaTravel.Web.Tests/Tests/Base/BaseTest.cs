using KamchatkaTravel.EntityFrameworkCore.EntityFrameworkCore;

namespace KamchatkaTravel.Web.Tests.Tests.Base
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
