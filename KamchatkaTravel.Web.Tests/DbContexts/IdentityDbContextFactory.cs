using KamchatkaTravel.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KamchatkaTravel.Web.Tests.DbContexts
{
    public class IdentityDbContextFactory
    {
        public static KamchatkaTravelIdentityDbContext Create()
        {
            var options = new DbContextOptionsBuilder<KamchatkaTravelIdentityDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new KamchatkaTravelIdentityDbContext(options);
            context.Database.EnsureCreated();
            context.PersonTelegrams.AddRange(
                new Identity.Models.PersonTelegram()
                {
                    Chat_Id = 753876757,
                    IsActive = true,
                    Id = 1,
                });
            context.SaveChanges();
            return context;
        }
        public static void Destroy(KamchatkaTravelIdentityDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }

}
