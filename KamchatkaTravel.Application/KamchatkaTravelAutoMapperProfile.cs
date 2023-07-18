using AutoMapper;
using KamchatkaTravel.Application.Contracts.DTOs.TourDTOs;
using KamchatkaTravel.Application.Contracts.DTOs.ReviewDTOs;
using KamchatkaTravel.Domain.Tours;
using KamchatkaTravel.Domain.Reviews;
using KamchatkaTravel.Application.Contracts.DTOs.DataDTOs;

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

            CreateMap<CreateQuestionDto, Question>().ReverseMap();
            CreateMap<CreateReviewDto, Review>().ReverseMap();
            CreateMap<CreateTourDto, Tour>()
                //.ForSourceMember(x=> x.LogoImage, opt => opt.DoNotValidate())
                //.ForMember(x => x.LogoImage,opt => opt.Ignore())
                .ReverseMap();
            CreateMap<CreateDayDto, Day>().ReverseMap();
            CreateMap<CreateImageDto, Image>().ReverseMap();
            CreateMap<CreateIncludeDto, Include>().ReverseMap();
            CreateMap<CreateViewDto, View>().ReverseMap();
        }
    }
}
