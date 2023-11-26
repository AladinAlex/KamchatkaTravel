using KamchatkaTravel.Domain.ClientRequests;
using KamchatkaTravel.Domain.Reviews;
using KamchatkaTravel.Domain.Shared.Tours;
using KamchatkaTravel.Domain.Tours;
using KamchatkaTravel.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Web.Tests.DbContexts
{
    public class DbContextFactory
    {
        public static KamchatkaTravelDbContext Create()
        {
            var options = new DbContextOptionsBuilder<KamchatkaTravelDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new KamchatkaTravelDbContext(options);
            context.Database.EnsureCreated();
            context.Tours.AddRange(
                new Tour
                {
                    Id = Guid.NewGuid(),
                    Name = "xUnitTestName1",
                    Tagline = "xUnitTestTagline1",
                    //LogoImageUrl = new byte[0],
                    SeasonType = SeasonType.All,
                    NightType = NightType.defaultValue,
                    Price = 100.00M,
                    Description = "xUnitTestDescription1",
                    DescriptionImage = new byte[0],
                    LinkEquipment = "xUnitTestLinkEquipment1",
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Tour
                {
                    Id = Guid.NewGuid(),
                    Name = "xUnitTestName2",
                    Tagline = "xUnitTestTagline2",
                    //LogoImageUrl = new byte[0],
                    SeasonType = SeasonType.Autumn,
                    NightType = NightType.withoutNight,
                    Price = 100.00M,
                    Description = "xUnitTestDescription2",
                    DescriptionImage = new byte[0],
                    LinkEquipment = "xUnitTestLinkEquipment2",
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Tour
                {
                    Id = Guid.NewGuid(),
                    Name = "xUnitTestName3",
                    Tagline = "xUnitTestTagline3",
                    //LogoImageUrl = new byte[0],
                    SeasonType = SeasonType.Winter,
                    NightType = NightType.TentAndFlat,
                    Price = 100.00M,
                    Description = "xUnitTestDescription3",
                    DescriptionImage = new byte[0],
                    LinkEquipment = "xUnitTestLinkEquipment3",
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Tour
                {
                    Id = Guid.NewGuid(),
                    Name = "xUnitTestName4",
                    Tagline = "xUnitTestTagline4",
                    //LogoImageUrl = new byte[0],
                    SeasonType = SeasonType.Spring,
                    NightType = NightType.GlampingAndHotel,
                    Price = 100.00M,
                    Description = "xUnitTestDescription4",
                    DescriptionImage = new byte[0],
                    LinkEquipment = "xUnitTestLinkEquipment4",
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                }
            );
            context.SaveChanges();
            context.Days.AddRange(
                new Day
                {
                    Id = Guid.NewGuid(),
                    Name = "dayName1",
                    Number = 1,
                    Description = "dayDescription1",
                    //ImageUrl = new byte[0],
                    tour = context.Tours.First(),
                    TourId = context.Tours.First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Name = "dayName2",
                    Number = 2,
                    Description = "dayDescription2",
                    //ImageUrl = new byte[0],
                    tour = context.Tours.First(),
                    TourId = context.Tours.First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Name = "dayName3",
                    Number = 3,
                    Description = "dayDescription3",
                    //ImageUrl = new byte[0],
                    tour = context.Tours.First(),
                    TourId = context.Tours.First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Name = "dayName4",
                    Number = 4,
                    Description = "dayDescription4",
                    //ImageUrl = new byte[0],
                    tour = context.Tours.First(),
                    TourId = context.Tours.First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Name = "dayName5",
                    Number = 5,
                    Description = "dayDescription5",
                    //ImageUrl = new byte[0],
                    tour = context.Tours.First(),
                    TourId = context.Tours.First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Name = "dayName6",
                    Number = 6,
                    Description = "dayDescription6",
                    //ImageUrl = new byte[0],
                    tour = context.Tours.Skip(1).Take(1).First(),
                    TourId = context.Tours.Skip(1).Take(1).First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Day
                {
                    Id = Guid.NewGuid(),
                    Name = "dayName7",
                    Number = 7,
                    Description = "dayDescription7",
                    //ImageUrl = new byte[0],
                    tour = context.Tours.Skip(1).Take(1).First(),
                    TourId = context.Tours.Skip(1).Take(1).First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                }
            );

            context.Images.AddRange(
                new Image
                {
                    Id = Guid.NewGuid(),
                    Img = new byte[0],
                    Ord = 1,
                    tour = context.Tours.First(),
                    TourId = context.Tours.First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Image
                {
                    Id = Guid.NewGuid(),
                    Img = new byte[0],
                    Ord = 2,
                    tour = context.Tours.First(),
                    TourId = context.Tours.First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Image
                {
                    Id = Guid.NewGuid(),
                    Img = new byte[0],
                    Ord = 3,
                    tour = context.Tours.First(),
                    TourId = context.Tours.First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Image
                {
                    Id = Guid.NewGuid(),
                    Img = new byte[0],
                    Ord = 1,
                    tour = context.Tours.Skip(1).Take(1).First(),
                    TourId = context.Tours.Skip(1).Take(1).First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Image
                {
                    Id = Guid.NewGuid(),
                    Img = new byte[0],
                    Ord = null,
                    tour = context.Tours.Skip(1).Take(1).First(),
                    TourId = context.Tours.Skip(1).Take(1).First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                }
            );

            context.Questions.AddRange(
                new Question
                {
                    Id = Guid.NewGuid(),
                    Name = "Question1",
                    Answer = "Answer1",
                    Ord = 1,
                    tour = context.Tours.First(),
                    TourId = context.Tours.First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Question
                {
                    Id = Guid.NewGuid(),
                    Name = "Question2",
                    Answer = "Answer2",
                    Ord = null,
                    tour = context.Tours.First(),
                    TourId = context.Tours.First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Question
                {
                    Id = Guid.NewGuid(),
                    Name = "Question2",
                    Answer = "Answer2",
                    Ord = 2,
                    tour = context.Tours.Skip(1).Take(1).First(),
                    TourId = context.Tours.Skip(1).Take(1).First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Question
                {
                    Id = Guid.NewGuid(),
                    Name = "Question1",
                    Answer = "Answer1",
                    Ord = 1,
                    tour = context.Tours.Skip(1).Take(1).First(),
                    TourId = context.Tours.Skip(1).Take(1).First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Question
                {
                    Id = Guid.NewGuid(),
                    Name = "Question3",
                    Answer = "Answer3",
                    Ord = 3,
                    tour = context.Tours.Skip(1).Take(1).First(),
                    TourId = context.Tours.Skip(1).Take(1).First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                }
            );

            context.Includes.AddRange(
                new Include
                {
                    Id = Guid.NewGuid(),
                    Number = 1,
                    Text = "Include1",
                    isInclude = true,
                    tour = context.Tours.First(),
                    TourId = context.Tours.First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Include
                {
                    Id = Guid.NewGuid(),
                    Number = 1,
                    Text = "noInclude1",
                    isInclude = false,
                    tour = context.Tours.First(),
                    TourId = context.Tours.First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Include
                {
                    Id = Guid.NewGuid(),
                    Number = 1,
                    Text = "Include1",
                    isInclude = true,
                    tour = context.Tours.Skip(1).Take(1).First(),
                    TourId = context.Tours.Skip(1).Take(1).First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Include
                {
                    Id = Guid.NewGuid(),
                    Number = 2,
                    Text = "Include2",
                    isInclude = true,
                    tour = context.Tours.Skip(1).Take(1).First(),
                    TourId = context.Tours.Skip(1).Take(1).First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Include
                {
                    Id = Guid.NewGuid(),
                    Number = 1,
                    Text = "noInclude1",
                    isInclude = false,
                    tour = context.Tours.Skip(1).Take(1).First(),
                    TourId = context.Tours.Skip(1).Take(1).First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                }
            );
            context.Reviews.AddRange(
                new Review
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Alex1",
                    LastName = "Aladin1",
                    Text = "Review1",
                    //LogoImage = new byte[0],
                    Date = DateTime.Now,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Alex2",
                    LastName = "Aladin2",
                    Text = "Review2",
                    //LogoImage = new byte[0],
                    Date = DateTime.Now,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Alex3",
                    LastName = "Aladin3",
                    Text = "Review3",
                    //LogoImage = new byte[0],
                    Date = DateTime.Now,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Alex4",
                    LastName = "Aladin4",
                    Text = "Review4",
                    //LogoImage = new byte[0],
                    Date = DateTime.Now,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Alex5",
                    LastName = "Aladin5",
                    Text = "Review5",
                    //LogoImage = new byte[0],
                    Date = DateTime.Now,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                }
            );
            context.Views.AddRange(
                new View
                {
                    Id = Guid.NewGuid(),
                    Name = "Name1",
                    Description = "Description1",
                    Image = new byte[0],
                    tour = context.Tours.First(),
                    TourId = context.Tours.First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new View
                {
                    Id = Guid.NewGuid(),
                    Name = "Name2",
                    Description = "Description2",
                    Image = new byte[0],
                    tour = context.Tours.First(),
                    TourId = context.Tours.First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true

                },
                new View
                {
                    Id = Guid.NewGuid(),
                    Name = "Name3",
                    Description = "Description3",
                    Image = new byte[0],
                    tour = context.Tours.First(),
                    TourId = context.Tours.First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true

                },
                new View
                {
                    Id = Guid.NewGuid(),
                    Name = "Name4",
                    Description = "Description4",
                    Image = new byte[0],
                    tour = context.Tours.Skip(1).Take(1).First(),
                    TourId = context.Tours.Skip(1).Take(1).First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true

                },
                new View
                {
                    Id = Guid.NewGuid(),
                    Name = "Name5",
                    Description = "Description5",
                    Image = new byte[0],
                    tour = context.Tours.Skip(1).Take(1).First(),
                    TourId = context.Tours.Skip(1).Take(1).First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true

                },
                new View
                {
                    Id = Guid.NewGuid(),
                    Name = "Name6",
                    Description = "Description6",
                    Image = new byte[0],
                    tour = context.Tours.Skip(2).Take(1).First(),
                    TourId = context.Tours.Skip(2).Take(1).First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true

                },
                new View
                {
                    Id = Guid.NewGuid(),
                    Name = "Name7",
                    Description = "Description7",
                    Image = new byte[0],
                    tour = context.Tours.Skip(3).Take(1).First(),
                    TourId = context.Tours.Skip(3).Take(1).First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true

                },
                new View
                {
                    Id = Guid.NewGuid(),
                    Name = "Name8",
                    Description = "Description8",
                    Image = new byte[0],
                    tour = context.Tours.Skip(3).Take(1).First(),
                    TourId = context.Tours.Skip(3).Take(1).First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true

                }
            );
            context.ClientRequests.AddRange(
                new ClientRequest
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Alex1",
                    Email = "ClientRequest1@mail.ru",
                    Phone = "89999999999",
                    isProcessed = true,
                    comment = "test2",
                    tour = context.Tours.First(),
                    TourId = context.Tours.First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new ClientRequest
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Alex2",
                    Email = "ClientRequest2@mail.ru",
                    Phone = "89999999999",
                    isProcessed = true,
                    comment = "test1",
                    tour = context.Tours.Skip(1).Take(1).First(),
                    TourId = context.Tours.Skip(1).Take(1).First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new ClientRequest
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Alex3",
                    Email = "ClientRequest3@mail.ru",
                    Phone = "89999999999",
                    isProcessed = true,
                    comment = "test3",
                    tour = context.Tours.Skip(2).Take(1).First(),
                    TourId = context.Tours.Skip(2).Take(1).First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new ClientRequest
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Alex4",
                    Email = "ClientRequest4@mail.ru",
                    Phone = "89999999999",
                    isProcessed = true,
                    comment = "test4",
                    tour = context.Tours.Skip(3).Take(1).First(),
                    TourId = context.Tours.Skip(3).Take(1).First().Id,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new ClientRequest
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Alex5",
                    Email = "ClientRequest5@mail.ru",
                    Phone = "89999999999",
                    isProcessed = true,
                    comment = "test5",
                    tour = null,
                    TourId = null,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                },
                new ClientRequest
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Alex6",
                    Email = "ClientRequest6@mail.ru",
                    Phone = "89999999999",
                    isProcessed = true,
                    comment = "test6",
                    tour = null,
                    TourId = null,
                    CreateDt = DateTime.UtcNow,
                    UpdateDt = null,
                    Visible = true
                }
            );
            context.SaveChanges();
            return context;
        }
        public static void Destroy(KamchatkaTravelDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
