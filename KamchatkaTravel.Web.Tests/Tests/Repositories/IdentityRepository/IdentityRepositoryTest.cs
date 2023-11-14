using KamchatkaTravel.Identity.Interfaces;
using KamchatkaTravel.Web.Tests.Tests.Base;


namespace KamchatkaTravel.Web.Tests.Tests.Repositories.IdentityRepository
{
    public class IdentityRepositoryTest : BaseIdentityRepositoryTest
    {
        [Fact]
        public async Task AddRole()
        {
            // Arrange
            IIdentityRepository identity = new KamchatkaTravel.Identity.Repositories.IdentityRepository(userManager, roleManager);

            // Assert
        }
    }
}
