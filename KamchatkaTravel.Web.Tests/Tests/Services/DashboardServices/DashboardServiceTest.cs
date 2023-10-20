using AutoMapper;
using KamchatkaTravel.Application.Contracts.DTOs.DataDTOs;
using KamchatkaTravel.Application.Contracts.DTOs.ReviewDTOs;
using KamchatkaTravel.Application.Contracts.DTOs.TourDTOs;
using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Application.Services;
using KamchatkaTravel.Domain.Interfaces;
using KamchatkaTravel.Domain.Shared.Tours;
using KamchatkaTravel.EntityFrameworkCore.Migrations;
using KamchatkaTravel.EntityFrameworkCore.Repositories;
using KamchatkaTravel.Web.Tests.Tests.Base;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KamchatkaTravel.Web.Tests.Tests.Servicies.DashboardServicies
{
    public class DashboardServiceTest : BaseServiceTest
    {
        [Fact]
        public async Task GetClientRequestsAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            // Act
            var result = await service.GetClientRequestsAsync();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(6, result.Count());
        }


        [Fact]
        public async Task ProcessRequest()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            foreach (var clReq in context.ClientRequests)
            {
                // Act
                var task = service.ProcessRequest(clReq.Id);
                var exp = await Record.ExceptionAsync(() => task);
                // Assert
                Assert.True(exp == null, $"ErrorError: {exp?.Message}");
            }
        }

        [Fact]
        public async Task GetClientRequestByIdAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            foreach (var clReq in context.ClientRequests)
            {
                // Act
                var result = await service.GetClientRequestByIdAsync(clReq.Id);
                // Assert
                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task EditClientRequest()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            foreach (var clReq in context.ClientRequests)
            {
                // Act
                var task = service.EditClientRequest(clReq.Id, clReq.Id.ToString());
                var exp = await Record.ExceptionAsync(() => task);
                // Assert
                Assert.True(exp == null, $"ErrorError: {exp?.Message}");
            }
        }

        [Fact]
        public async Task DeleteClientRequest()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            var list = context.ClientRequests;
            foreach (var clReq in list)
            {
                // Act
                var task = service.DeleteClientRequest(clReq.Id);
                var exp = await Record.ExceptionAsync(() => task);
                // Assert
                Assert.True(exp == null, $"ErrorError: {exp?.Message}");
            }
        }

        [Fact]
        public async Task GetToursAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            // Act
            var result = await service.GetToursAsync();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Count());
        }

        [Fact]
        public async Task GetReviewsAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            // Act
            var result = await service.GetReviewsAsync();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Count());
        }

        [Fact]
        public async Task GetTourByIdAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            foreach (var tour in context.Tours)
            {
                // Act
                var result = await service.GetTourByIdAsync(tour.Id);
                // Assert
                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task EditTourAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            foreach (var tour in context.Tours)
            {
                var newTour = new TourViewModel
                {
                    Id = tour.Id,
                    Name = Tools.Tools.RandomText(50),
                    Description = Tools.Tools.RandomText(100),
                    Tagline = Tools.Tools.RandomText(70),
                    LinkEquipment = Tools.Tools.RandomText(15),
                    Price = decimal.Parse(Tools.Tools.RandomNumber(7000, 11500).ToString()),
                };
                // Act
                var task = service.EditTourAsync(newTour);
                var exp = await Record.ExceptionAsync(() => task);
                // Assert
                Assert.True(exp == null, $"ErrorError: {exp?.Message}");
            }
        }

        [Fact]
        public async Task EditViewAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            foreach (var view in context.Views)
            {
                var newView = new ViewModel
                {
                    Id = view.Id,
                    Name = Tools.Tools.RandomText(50),
                    Description = Tools.Tools.RandomText(100),
                };
                // Act
                var task = service.EditViewAsync(newView);
                var exp = await Record.ExceptionAsync(() => task);
                // Assert
                Assert.True(exp == null, $"ErrorError: {exp?.Message}");
            }
        }

        [Fact]
        public async Task CreateTourAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            // Act
            var newTour = new CreateTourDto
            {
                Name = Tools.Tools.RandomText(7),
                Tagline = Tools.Tools.RandomText(15),
                SeasonType = SeasonType.Winter,
                NightType = NightType.GlampingAndHotel,
                Price = decimal.Parse(Tools.Tools.RandomNumber(7000, 11500).ToString()),
                Description = Tools.Tools.RandomText(30),
                LinkEquipment = Tools.Tools.RandomText(15),
            };
            var task = service.CreateTourAsync(newTour);
            var exp = await Record.ExceptionAsync(() => task);
            // Assert
            Assert.True(exp == null, $"ErrorError: {exp?.Message}");
        }

        [Fact]
        public async Task CreateTourViewAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            // Act
            var newView = new CreateViewDto
            {
                Name = Tools.Tools.RandomText(7),
                Description = Tools.Tools.RandomText(100),
                Image = null,
                TourId = context.Tours.First().Id,

            };
            var task = service.CreateTourViewAsync(newView);
            var exp = await Record.ExceptionAsync(() => task);
            // Assert
            Assert.True(exp == null, $"ErrorError: {exp?.Message}");
        }

        [Fact]
        public async Task CreateTourImageAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            // Act
            var newImg = new CreateImageDto
            {
                Image = null,
                Ord = Tools.Tools.RandomNumber(1, 7),
                TourId = context.Tours.First().Id,

            };
            var task = service.CreateTourImageAsync(newImg);
            var exp = await Record.ExceptionAsync(() => task);
            // Assert
            Assert.True(exp == null, $"ErrorError: {exp?.Message}");
        }


        [Fact]
        public async Task CreateTourDayAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            // Act
            var newDay = new CreateDayDto
            {
                Name = Tools.Tools.RandomText(8),
                Number = Tools.Tools.RandomNumber(1, 8),
                Description = Tools.Tools.RandomText(30),
                TourId = context.Tours.First().Id,

            };
            var task = service.CreateTourDayAsync(newDay);
            var exp = await Record.ExceptionAsync(() => task);
            // Assert
            Assert.True(exp == null, $"ErrorError: {exp?.Message}");
        }

        [Fact]
        public async Task CreateReviewAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            // Act
            var newReview = new CreateReviewDto
            {
                FirstName = Tools.Tools.RandomText(8),
                LastName = Tools.Tools.RandomText(10),
                Text = Tools.Tools.RandomText(40),
                Date = DateTime.Now,
            };
            var task = service.CreateReviewAsync(newReview);
            var exp = await Record.ExceptionAsync(() => task);
            // Assert
            Assert.True(exp == null, $"ErrorError: {exp?.Message}");
        }

        [Fact]
        public async Task CreateTourQuestionAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            // Act
            var newQ = new CreateQuestionDto
            {
                Name = Tools.Tools.RandomText(20),
                Answer = Tools.Tools.RandomText(35),
                Ord = Tools.Tools.RandomNumber(1, 10),
                TourId = context.Tours.First().Id,

            };
            var task = service.CreateTourQuestionAsync(newQ);
            var exp = await Record.ExceptionAsync(() => task);
            // Assert
            Assert.True(exp == null, $"ErrorError: {exp?.Message}");
        }

        [Fact]
        public async Task CreateTourIncludeAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            // Act
            var newIncl = new CreateIncludeDto
            {
                Number = Tools.Tools.RandomNumber(1, 10),
                Text = Tools.Tools.RandomText(45),
                isInclude = true,
                TourId = context.Tours.First().Id,
            };
            var task = service.CreateTourIncludeAsync(newIncl);
            var exp = await Record.ExceptionAsync(() => task);
            // Assert
            Assert.True(exp == null, $"ErrorError: {exp?.Message}");
        }

        [Fact]
        public async Task GetViewByIdAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            // Act
            foreach (var view in context.Views)
            {
                var result = await service.GetViewByIdAsync(view.Id);
                // Assert
                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task GetImageByIdAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            // Act
            foreach (var img in context.Images)
            {
                var result = await service.GetImageByIdAsync(img.Id);
                // Assert
                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task GetDayByIdAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            // Act
            foreach (var day in context.Days)
            {
                var result = await service.GetDayByIdAsync(day.Id);
                // Assert
                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task GetReviewByIdAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            // Act
            foreach (var review in context.Reviews)
            {
                var result = await service.GetReviewByIdAsync(review.Id);
                // Assert
                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task GetQuestionByIdAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            // Act
            foreach (var q in context.Questions)
            {
                var result = await service.GetQuestionByIdAsync(q.Id);
                // Assert
                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task GetIncludeByIdAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            // Act
            foreach (var include in context.Includes)
            {
                var result = await service.GetIncludeByIdAsync(include.Id);
                // Assert
                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task EditImageAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            foreach (var img in context.Images)
            {
                // Act
                var model = new ImageModel
                {
                    Id = img.Id,
                    Visible = true,
                    TourId = img.TourId,
                    Ord = Tools.Tools.RandomNumber(1, 20),
                };
                var task = service.EditImageAsync(model);
                var exp = await Record.ExceptionAsync(() => task);
                // Assert
                Assert.True(exp == null, $"ErrorError: {exp?.Message}");
            }
        }

        [Fact]
        public async Task EditDayAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            foreach (var day in context.Days)
            {
                // Act
                var model = new DayModel
                {
                    Id = day.Id,
                    Visible = true,
                    TourId = day.TourId,
                    Name = Tools.Tools.RandomText(50),
                    Description = Tools.Tools.RandomText(100),
                    Number = Tools.Tools.RandomNumber(1, 100),
                };
                var task = service.EditDayAsync(model);
                var exp = await Record.ExceptionAsync(() => task);
                // Assert
                Assert.True(exp == null, $"ErrorError: {exp?.Message}");
            }
        }

        [Fact]
        public async Task EditReviewAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            foreach (var review in context.Reviews)
            {
                // Act
                var model = new ReviewModel
                {
                    Id = review.Id,
                    Visible = true,
                    FirstName = Tools.Tools.RandomText(8),
                    LastName = Tools.Tools.RandomText(10),
                    Text = Tools.Tools.RandomText(150),
                };
                var task = service.EditReviewAsync(model);
                var exp = await Record.ExceptionAsync(() => task);
                // Assert
                Assert.True(exp == null, $"ErrorError: {exp?.Message}");
            }
        }

        [Fact]
        public async Task EditQuestionAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            foreach (var q in context.Questions)
            {
                // Act
                var model = new QuestionModel
                {
                    Id = q.Id,
                    Visible = true,
                    Name = Tools.Tools.RandomText(20),
                    Answer = Tools.Tools.RandomText(40),
                    Ord = Tools.Tools.RandomNumber(1, 20),
                };
                var task = service.EditQuestionAsync(model);
                var exp = await Record.ExceptionAsync(() => task);
                // Assert
                Assert.True(exp == null, $"ErrorError: {exp?.Message}");
            }
        }

        [Fact]
        public async Task EditIncludeAsync()
        {
            // Arrange
            IDashboardRepository repository = new DashboardRepository(context);
            IDashboardService service = new DashboardService(repository, mapper);
            foreach (var include in context.Includes)
            {
                // Act
                var model = new IncludeModel
                {
                    Id = include.Id,
                    Visible = true,
                    Number = Tools.Tools.RandomNumber(1, 20),
                    Text = Tools.Tools.RandomText(25),
                };
                var task = service.EditIncludeAsync(model);
                var exp = await Record.ExceptionAsync(() => task);
                // Assert
                Assert.True(exp == null, $"ErrorError: {exp?.Message}");
            }
        }
    }
}
