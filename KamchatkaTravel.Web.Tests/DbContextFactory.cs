using KamchatkaTravel.Domain.ClientRequests;
using KamchatkaTravel.Domain.Reviews;
using KamchatkaTravel.Domain.Shared.Tours;
using KamchatkaTravel.Domain.Tours;
using KamchatkaTravel.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Web.Tests
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
            context.Tours.AddRange(new Tour {
                Id = Guid.NewGuid(),
                Name = "xUnitTestName1",
                Tagline = "xUnitTestTagline1",
                LogoImage = new byte[0],
                SeasonType = SeasonType.All,
                NightType = NightType.defaultValue,
                Price = 100.00M,
                Description = "xUnitTestDescription1",
                DescriptionImage = new byte[0],
                LinkEquipment = "xUnitTestLinkEquipment1"
            },
                    new Tour
                    {
                        Id = Guid.NewGuid(),
                        Name = "xUnitTestName2",
                        Tagline = "xUnitTestTagline2",
                        LogoImage = new byte[0],
                        SeasonType = SeasonType.Autumn,
                        NightType = NightType.withoutNight,
                        Price = 100.00M,
                        Description = "xUnitTestDescription2",
                        DescriptionImage = new byte[0],
                        LinkEquipment = "xUnitTestLinkEquipment2"
                    },
                    new Tour
                    {
                        Id = Guid.NewGuid(),
                        Name = "xUnitTestName3",
                        Tagline = "xUnitTestTagline3",
                        LogoImage = new byte[0],
                        SeasonType = SeasonType.Winter,
                        NightType = NightType.TentAndFlat,
                        Price = 100.00M,
                        Description = "xUnitTestDescription3",
                        DescriptionImage = new byte[0],
                        LinkEquipment = "xUnitTestLinkEquipment3"
                    },
                    new Tour
                    {
                        Id = Guid.NewGuid(),
                        Name = "xUnitTestName4",
                        Tagline = "xUnitTestTagline4",
                        LogoImage = new byte[0],
                        SeasonType = SeasonType.Spring,
                        NightType = NightType.GlampingAndHotel,
                        Price = 100.00M,
                        Description = "xUnitTestDescription4",
                        DescriptionImage = new byte[0],
                        LinkEquipment = "xUnitTestLinkEquipment4"
                    }
            );
            context.Days.AddRange(new Day
            {
                Id = Guid.NewGuid(),
                Name = "dayName1",
                Number = 1,
                Description = "dayDescription1",
                Image = new byte[0],
                tour = context.Tours.First(),
                TourId = context.Tours.First().Id
            });
            context.Images.AddRange(new Image {

            });
            context.Questions.AddRange(new Question {

            });
            context.Includes .AddRange(new Include {

            });
            context.Reviews .AddRange(new Review {

            });
            context.Views .AddRange(new View {

            });
            context.ClientRequests.AddRange(new ClientRequest {

            });

        }
    }
}
