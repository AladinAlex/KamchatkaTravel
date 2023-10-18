using KamchatkaTravel.Domain.Interfaces;
using KamchatkaTravel.Web.Tests.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Web.Tests.Tests.TourRepositories
{
    public class TourRepositoryTest : BaseTest
    {
        [Fact]
        public async Task GetToursAsync()
        {
            // Arrange
            ITourRepository rep = new KamchatkaTravel.EntityFrameworkCore.Repositories.TourRepository(context);
            // Act
            var result = await rep.GetToursAsync();
            // Assert
            Assert.Equal(4, result.Count());
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetQuestionsAsync()
        {
            // Arrange
            ITourRepository rep = new KamchatkaTravel.EntityFrameworkCore.Repositories.TourRepository(context);
            // Act
            var result = await rep.GetQuestionsAsync();
            // Assert
            Assert.Equal(5, result.Count());
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CreateClientRequest()
        {
            // Arrange
            ITourRepository rep = new KamchatkaTravel.EntityFrameworkCore.Repositories.TourRepository(context);

            string FirstName1 = Tools.Tools.RandomText(8);
            string Email1 = String.Join("", Tools.Tools.RandomText(8), "@", Tools.Tools.RandomText(5), ".", Tools.Tools.RandomText(2));
            string Phone1 = "89897776655";
            string FirstName2 = Tools.Tools.RandomText(8);
            string Email2 = String.Join("", Tools.Tools.RandomText(8), "@", Tools.Tools.RandomText(5), ".", Tools.Tools.RandomText(2));
            string Phone2 = "89897776655";
            // Act
            var task1 = rep.CreateClientRequest(FirstName1, Email1, Phone1, null);
            var task2 = rep.CreateClientRequest(FirstName2, Email2, Phone2, context.Tours.First().Id);

            var exp1 = await Record.ExceptionAsync(() => task1);
            var exp2 = await Record.ExceptionAsync(() => task2);

            // Assert
            Assert.True(exp1 == null, $"ErrorError: {exp1?.Message}");
            Assert.True(exp2 == null, $"ErrorError: {exp2?.Message}");
        }

        [Fact]
        public async Task GetTop5ReviewsAsync()
        {
            // Arrange
            ITourRepository rep = new KamchatkaTravel.EntityFrameworkCore.Repositories.TourRepository(context);
            // Act
            var result = await rep.GetTop5ReviewsAsync();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Count());
        }

        [Fact]
        public async Task GetTourByIdAsync()
        {
            // Arrange
            IDashboardRepository dashboard = new KamchatkaTravel.EntityFrameworkCore.Repositories.DashboardRepository(context);

            foreach (var tour in context.Tours)
            {
                // Act
                var result = await dashboard.GetTourByIdAsync(tour.Id);
                // Assert
                Assert.NotNull(result);
            }
        }
    }
}
