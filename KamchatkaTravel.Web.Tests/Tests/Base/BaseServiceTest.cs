using AutoMapper;
using KamchatkaTravel.Application;
using KamchatkaTravel.EntityFrameworkCore.EntityFrameworkCore;

namespace KamchatkaTravel.Web.Tests.Tests.Base
{
    public abstract class BaseServiceTest : BaseRepositoryTest
    {
        //protected readonly KamchatkaTravelDbContext context;
        protected readonly IMapper mapper;
        public BaseServiceTest()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new KamchatkaTravelAutoMapperProfile());
            });
            mapper = mapperConfig.CreateMapper();
        }
    }
}
