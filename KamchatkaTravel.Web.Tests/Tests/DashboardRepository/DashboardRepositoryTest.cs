﻿using KamchatkaTravel.Domain.Interfaces;
using KamchatkaTravel.Web.Tests.Tests.Base;
using KamchatkaTravel.EntityFrameworkCore.Repositories;
using KamchatkaTravel.Domain.Tours;
using KamchatkaTravel.Domain.Shared.Tours;

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

        [Fact]
        public async Task UpdateProcessClientRequestAsync()
        {
            // Arrange
            IDashboardRepository dashboard = new KamchatkaTravel.EntityFrameworkCore.Repositories.DashboardRepository(context);

            foreach (var clReq in context.ClientRequests.Where(x => x.Visible && !x.isProcessed))
            {
                // Act
                var task = dashboard.UpdateProcessClientRequestAsync(clReq.Id);
                var exp = await Record.ExceptionAsync(() => task);
                // Assert
                Assert.True(exp == null, $"Error: {exp.Message}");
            }
        }

        [Fact]
        public async Task SelectClientRequestByIdAsync()
        {
            // Arrange
            IDashboardRepository dashboard = new KamchatkaTravel.EntityFrameworkCore.Repositories.DashboardRepository(context);

            foreach (var clReq in context.ClientRequests.Where(x => x.Visible && !x.isProcessed))
            {
                // Act
                var result = await dashboard.SelectClientRequestByIdAsync(clReq.Id);
                // Assert
                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task UpdateClientRequestByIdAsync()
        {
            // Arrange
            IDashboardRepository dashboard = new KamchatkaTravel.EntityFrameworkCore.Repositories.DashboardRepository(context);

            foreach (var clReq in context.ClientRequests)
            {
                // Act
                var task = dashboard.UpdateClientRequestByIdAsync(clReq.Id, $"CliendId: {clReq.Id}");
                var exp = await Record.ExceptionAsync(() => task);
                // Assert
                Assert.True(exp == null, $"Error: {exp?.Message}");
            }
        }

        [Fact]
        public async Task DeleteClientRequestByIdAsync()
        {
            // Arrange
            IDashboardRepository dashboard = new KamchatkaTravel.EntityFrameworkCore.Repositories.DashboardRepository(context);

            foreach (var clReq in context.ClientRequests.Where(x => x.Visible && !x.isProcessed))
            {
                // Act
                var task = dashboard.DeleteClientRequestByIdAsync(clReq.Id);
                var exp = await Record.ExceptionAsync(() => task);
                // Assert
                Assert.True(exp == null, $"Error: {exp.Message}");
            }
        }

        [Fact]
        public async Task SelectTourAllAsync()
        {
            // Arrange
            IDashboardRepository dashboard = new KamchatkaTravel.EntityFrameworkCore.Repositories.DashboardRepository(context);
            // Act
            var result = await dashboard.SelectTourAllAsync();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Count());

        }

        [Fact]
        public async Task SelectReviewAllAsync()
        {
            // Arrange
            IDashboardRepository dashboard = new KamchatkaTravel.EntityFrameworkCore.Repositories.DashboardRepository(context);
            // Act
            var result = await dashboard.SelectReviewAllAsync();
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

        [Fact]
        public async Task UpdateTourAsync()
        {
            // Arrange
            IDashboardRepository dashboard = new KamchatkaTravel.EntityFrameworkCore.Repositories.DashboardRepository(context);

            foreach (var tour in context.Tours)
            {
                tour.Name = Tools.Tools.RandomText(50);
                tour.Description = Tools.Tools.RandomText(100);
                tour.Tagline = Tools.Tools.RandomText(70);
                tour.LinkEquipment = Tools.Tools.RandomText(15);
                tour.Price = decimal.Parse(Tools.Tools.RandomNumber(7000, 11500).ToString());
                // Act
                var task = dashboard.UpdateTourAsync(tour);
                var exp = await Record.ExceptionAsync(() => task);
                // Assert
                Assert.True(exp == null, $"Error: {exp?.Message}");
            }
        }

        [Fact]
        public async Task UpdateViewAsync()
        {
            // Arrange
            IDashboardRepository dashboard = new KamchatkaTravel.EntityFrameworkCore.Repositories.DashboardRepository(context);

            foreach (var view in context.Views)
            {

                view.Name = Tools.Tools.RandomText(50);
                view.Description = Tools.Tools.RandomText(100);
                // Act
                var task = dashboard.UpdateViewAsync(view);
                var exp = await Record.ExceptionAsync(() => task);
                // Assert
                Assert.True(exp == null, $"Error: {exp?.Message}");
            }
        }

        [Fact]
        public async Task UpdateImageAsync()
        {
            // Arrange
            IDashboardRepository dashboard = new KamchatkaTravel.EntityFrameworkCore.Repositories.DashboardRepository(context);

            foreach (var image in context.Images)
            {
                image.Ord = Tools.Tools.RandomNumber(1,20);
                // Act
                var task = dashboard.UpdateImageAsync(image);
                var exp = await Record.ExceptionAsync(() => task);
                // Assert
                Assert.True(exp == null, $"Error: {exp?.Message}");
            }
        }

        [Fact]
        public async Task UpdateDayAsync()
        {
            // Arrange
            IDashboardRepository dashboard = new KamchatkaTravel.EntityFrameworkCore.Repositories.DashboardRepository(context);

            foreach (var day in context.Days)
            {
                day.Name = Tools.Tools.RandomText(50);
                day.Description = Tools.Tools.RandomText(100);
                day.Number = Tools.Tools.RandomNumber(1, 100);
                // Act
                var task = dashboard.UpdateDayAsync(day);
                var exp = await Record.ExceptionAsync(() => task);
                // Assert
                Assert.True(exp == null, $"Error: {exp?.Message}");
            }
        }

        [Fact]
        public async Task UpdateReviewAsync()
        {
            // Arrange
            IDashboardRepository dashboard = new KamchatkaTravel.EntityFrameworkCore.Repositories.DashboardRepository(context);

            foreach (var review in context.Reviews)
            {
                review.FirstName = Tools.Tools.RandomText(8);
                review.LastName = Tools.Tools.RandomText(10);
                review.Text = Tools.Tools.RandomText(150);
                // Act
                var task = dashboard.UpdateReviewAsync(review);
                var exp = await Record.ExceptionAsync(() => task);
                // Assert
                Assert.True(exp == null, $"Error: {exp?.Message}");
            }
        }

        [Fact]
        public async Task UpdateQuestionAsync()
        {
            // Arrange
            IDashboardRepository dashboard = new KamchatkaTravel.EntityFrameworkCore.Repositories.DashboardRepository(context);

            foreach (var q in context.Questions)
            {
                q.Name = Tools.Tools.RandomText(20);
                q.Answer = Tools.Tools.RandomText(40);
                q.Ord = Tools.Tools.RandomNumber(1, 20);
                // Act
                var task = dashboard.UpdateQuestionAsync(q);
                var exp = await Record.ExceptionAsync(() => task);
                // Assert
                Assert.True(exp == null, $"Error: {exp?.Message}");
            }
        }

        [Fact]
        public async Task UpdateIncludeAsync()
        {
            // Arrange
            IDashboardRepository dashboard = new KamchatkaTravel.EntityFrameworkCore.Repositories.DashboardRepository(context);

            foreach (var include in context.Includes)
            {
                include.Number = Tools.Tools.RandomNumber(1, 20);
                include.Text = Tools.Tools.RandomText(25);
                // Act
                var task = dashboard.UpdateIncludeAsync(include);
                var exp = await Record.ExceptionAsync(() => task);
                // Assert
                Assert.True(exp == null, $"Error: {exp?.Message}");
            }
        }

        [Fact]
        public async Task InsertTourAsync()
        {
            // Arrange
            IDashboardRepository dashboard = new KamchatkaTravel.EntityFrameworkCore.Repositories.DashboardRepository(context);
            var newTour = new Tour
            {
                Id = Guid.NewGuid(),
                Name = Tools.Tools.RandomText(7),
                Tagline = Tools.Tools.RandomText(15),
                LogoImage = new byte[0],
                SeasonType = SeasonType.Winter,
                NightType = NightType.GlampingAndHotel,
                Price = decimal.Parse(Tools.Tools.RandomNumber(7000, 11500).ToString()),
                Description = Tools.Tools.RandomText(30),
                DescriptionImage = new byte[0],
                LinkEquipment = Tools.Tools.RandomText(15),
                CreateDt = DateTime.Now,
                UpdateDt = null,
                Visible = true
            };
            // Act
            var task = dashboard.InsertTourAsync(newTour);
            var exp = await Record.ExceptionAsync(() => task);
            // Assert
            Assert.True(exp == null, $"Error: {exp?.Message}");
        }

        [Fact]
        public async Task InsertViewAsync()
        {
            // Arrange
            IDashboardRepository dashboard = new KamchatkaTravel.EntityFrameworkCore.Repositories.DashboardRepository(context);
            var newView = new View
            {
                Id = Guid.NewGuid(),
                Name = Tools.Tools.RandomText(8),
                Description = Tools.Tools.RandomText(15),
                Image = new byte[0],
                tour = context.Tours.First(),
                TourId = context.Tours.First().Id,
                CreateDt = DateTime.UtcNow,
                UpdateDt = null,
                Visible = true
            };
            // Act
            var task = dashboard.InsertViewAsync(newView);
            var exp = await Record.ExceptionAsync(() => task);
            // Assert
            Assert.True(exp == null, $"Error: {exp?.Message}");
        }

        [Fact]
        public async Task InsertImageAsync()
        {
            // Arrange
            IDashboardRepository dashboard = new KamchatkaTravel.EntityFrameworkCore.Repositories.DashboardRepository(context);
            var newImage = new Image
            {
                Id = Guid.NewGuid(),
                Img = new byte[0],
                Ord = Tools.Tools.RandomNumber(1,10),
                tour = context.Tours.Skip(1).Take(1).First(),
                TourId = context.Tours.Skip(1).Take(1).First().Id,
                CreateDt = DateTime.UtcNow,
                UpdateDt = null,
                Visible = true
            };
            // Act
            var task = dashboard.InsertImageAsync(newImage);
            var exp = await Record.ExceptionAsync(() => task);
            // Assert
            Assert.True(exp == null, $"Error: {exp?.Message}");
        }

        //GetViewByIdAsync

    }
}
