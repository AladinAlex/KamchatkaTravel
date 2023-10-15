using KamchatkaTravel.Domain.Interfaces;
using KamchatkaTravel.EntityFrameworkCore.EntityFrameworkCore;
using KamchatkaTravel.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Web.Tests
{
    public class DashboardRepositoryTest : BaseTest
    {
        [Fact]
        public async Task SelectClientRequestAllAsync()
        {
            // Arrange
            IDashboardRepository dashboard = new DashboardRepository(context);
            // Act
            var result = await dashboard.SelectClientRequestAllAsync();
            // Assert
            Assert.NotNull(result);
        }
    }
}
    