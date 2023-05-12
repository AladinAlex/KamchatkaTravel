using AutoMapper;
using KamchatkaTravel.Application.Contracts.DTOs.TourDTOs;
using KamchatkaTravel.Application.Contracts.DTOs.ReviewDTOs;
using KamchatkaTravel.Domain.Tours;
using KamchatkaTravel.Domain.Reviews;

namespace KamchatkaTravel.Application
{
    public  class KamchatkaTravelAutoMapperProfile : Profile
    {
        public KamchatkaTravelAutoMapperProfile()
        {
            CreateMap<Tour, TourDto>().ReverseMap();
            CreateMap<Day, DayDto>();

            CreateMap<IEnumerable<Tour>, List<TourDto>>().ReverseMap();

            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<View, ViewDto>().ReverseMap();
            CreateMap<Image, ImageDto>().ReverseMap();
            CreateMap<Include, IncludeDto>().ReverseMap();
            CreateMap<Review, ReviewDto>().ReverseMap();

            CreateMap<IEnumerable<Day>, List<DayDto>>().ReverseMap();

            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<OuterSource, OuterDest>();
            //    cfg.CreateMap<InnerSource, InnerDest>();
            //});
        }
    }
}
