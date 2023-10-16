using KamchatkaTravel.Domain.Interfaces;
using KamchatkaTravel.Web.Tests.Tests.Base;
using KamchatkaTravel.EntityFrameworkCore.Repositories;

namespace KamchatkaTravel.Web.Tests.Tests.DashboardRepository
{
    public class DashboardRepositoryTest : BaseTest
    {
        [Fact]
        public async Task SelectClientRequestAllAsync()
        {
            // Arrange
            IDashboardRepository dashboard = new KamchatkaTravel.EntityFrameworkCore.Repositories.DashboardRepository(context);
            // Act
            var result = await dashboard.SelectClientRequestAllAsync();
            // Assert
            Assert.NotNull(result);
        }
    }
}
