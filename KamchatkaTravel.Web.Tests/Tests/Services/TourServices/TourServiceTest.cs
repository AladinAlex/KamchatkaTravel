using KamchatkaTravel.Application.Contracts.DTOs.ClientRequestDTOs;
using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Application.Services;
using KamchatkaTravel.Domain.Interfaces;
using KamchatkaTravel.EntityFrameworkCore.Repositories;
using KamchatkaTravel.Web.Tests.Tests.Base;

namespace KamchatkaTravel.Web.Tests.Tests.Servicies.TourServicies
{
    public class TourServiceTest : BaseServiceTest
    {
        [Fact]
        public async Task Index()
        {
            // Arrange
            ITourRepository repository = new TourRepository(context);
            ITourService service = new TourService(mapper, repository);
            // Act
            var result = await service.Index();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Tours.Count());
            Assert.Equal(5, result.Questions.Count());
            Assert.Equal(5, result.Reviews.Count());
        }


        [Fact]
        public async Task GetTourInfo()
        {
            // Arrange
            ITourRepository repository = new TourRepository(context);
            ITourService service = new TourService(mapper, repository);
            // Act
            foreach (var tour in context.Tours)
            {
                var result = await service.GetTourInfo(tour.Id);
                // Assert
                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task CreateClientRequest()
        {
            // Arrange
            ITourRepository repository = new TourRepository(context);
            ITourService service = new TourService(mapper, repository);
            var CRnew1 = new ClientRequestCreateDto
            {
                FirstName = Tools.Tools.RandomText(8),
                Email = string.Join("", Tools.Tools.RandomText(8), "@", Tools.Tools.RandomText(5), ".", Tools.Tools.RandomText(2)),
                Phone = "89897776655",
                TourId = null,
            };
            var CRnew2 = new ClientRequestCreateDto
            {
                FirstName = Tools.Tools.RandomText(8),
                Email = string.Join("", Tools.Tools.RandomText(8), "@", Tools.Tools.RandomText(5), ".", Tools.Tools.RandomText(2)),
                Phone = "89897776655",
                TourId = context.Tours.First().Id,
            };
            // Act
            var task1 = service.CreateClientRequest(CRnew1);
            var task2 = service.CreateClientRequest(CRnew2);
            var exp1 = await Record.ExceptionAsync(() => task1);
            var exp2 = await Record.ExceptionAsync(() => task2);
            // Assert
            Assert.True(exp1 == null, $"ErrorError: {exp1?.Message}");
            Assert.True(exp2 == null, $"ErrorError: {exp2?.Message}");
        }
    }
}
