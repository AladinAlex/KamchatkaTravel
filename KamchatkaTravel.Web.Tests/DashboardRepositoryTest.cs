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
    public abstract class DashboardRepositoryTest : IDisposable
    {
        readonly KamchatkaTravelDbContext context;
        public DashboardRepositoryTest()
        {
            context = DbContextFactory.Create();
            
        }
        public void Dispose() 
        {
            DbContextFactory.Destroy(context);
        }

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
    