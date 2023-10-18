using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Application.Services;
using KamchatkaTravel.Domain.Interfaces;
using KamchatkaTravel.EntityFrameworkCore.Repositories;
using KamchatkaTravel.Web.Tests.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Web.Tests.Tests.Servicies.TourServicies
{
    public class TourServiceTest : BaseServiceTest
    {
        ITourService service;

        [Fact]
        public async Task Index()
        {
            // Arrange
            ITourRepository repository = new TourRepository(context);
            service = new TourService(mapper, repository);
            // Act
            var result = await service.Index();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Tours.Count());
            Assert.Equal(5, result.Questions.Count());
            Assert.Equal(5, result.Reviews.Count());
        }
    }
}
