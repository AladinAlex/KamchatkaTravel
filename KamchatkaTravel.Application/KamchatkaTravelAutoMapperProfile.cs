﻿using AutoMapper;
using KamchatkaTravel.Application.Contracts.DTOs.TourDTOs;
using KamchatkaTravel.Application.Contracts.DTOs.ReviewDTOs;
using KamchatkaTravel.Domain.Tours;
using KamchatkaTravel.Domain.Reviews;
using KamchatkaTravel.Application.Contracts.DTOs.DataDTOs;
using System.Collections.Generic;
using KamchatkaTravel.Application.Contracts.DTOs;
using KamchatkaTravel.Application.Contracts.DTOs.ClientRequestDTOs;
using KamchatkaTravel.Domain.ClientRequests;
using KamchatkaTravel.Identity.Models;
using KamchatkaTravel.Application.Contracts.Common;
using System;

namespace KamchatkaTravel.Application
{
    public class KamchatkaTravelAutoMapperProfile : Profile
    {
        public KamchatkaTravelAutoMapperProfile()
        {
            CreateMap<Tour, TourDto>().ReverseMap();
            CreateMap<Day, DayDto>().ReverseMap();

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
            CreateMap<CreateImageDto, Image>().ReverseMap();
            CreateMap<CreateDayDto, Day>().ReverseMap();

            CreateMap<CreateIncludeDto, Include>().ReverseMap();
            CreateMap<CreateViewDto, View>()
                .ReverseMap();

            CreateMap<Tour, SimpleTour>().ReverseMap();
            CreateMap<IEnumerable<Tour>, GetToursResponse>()
                .ForMember(dto => dto.tours, opt => opt.MapFrom(x => x.ToList()))
                .ReverseMap();

            CreateMap<Tour, TourDetailsDto>();
            CreateMap<Day, DayDto>();
            CreateMap<ClientRequest, ClientRequestViewModel>()
                .ForMember(dto => dto.tourName, opt => opt.MapFrom(x => x.tour != null ? x.tour.Name : ""));

            CreateMap<Tour, TourViewModel>().ReverseMap();
            CreateMap<Tour, UpdateTourDto>().ReverseMap();
            CreateMap<View, ViewModel>().ReverseMap();
            CreateMap<Image, ImageModel>().ReverseMap();
            CreateMap<Day, DayModel>().ReverseMap();
            CreateMap<Question, QuestionModel>().ReverseMap();
            CreateMap<Include, IncludeModel>().ReverseMap();

            
            CreateMap<IdentityResponse, ServiceResponse>()
                .ForMember(dto => dto.ResponseId, opt => opt.MapFrom(x => x.ResponseId))
                .ForMember(dto => dto.Error, opt => opt.MapFrom(x => x.Error))
                .ForMember(dto => dto.ResponseCode, opt => opt.MapFrom(x => (ResponseCode)Enum.Parse(typeof(ResponseCode), x.Status.ToString()) )); // выглядит очень не надежно

            CreateMap<CreateReviewDto, Review>()
                .ForMember(dto => dto.LogoImageUrl, opt => opt.MapFrom(x => x.LogoPath));
;
            CreateMap<ReviewViewModel, Review>().ReverseMap();
            CreateMap<Review, ReviewModel>().ReverseMap();
        }
    }
}
