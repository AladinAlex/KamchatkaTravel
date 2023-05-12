using AutoMapper;
using KamchatkaTravel.Application.Contracts.DTOs;
using KamchatkaTravel.Application.Contracts.DTOs.ClientRequestDTOs;
using KamchatkaTravel.Application.Contracts.DTOs.ReviewDTOs;
using KamchatkaTravel.Application.Contracts.DTOs.TourDTOs;
using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Domain.ClientRequests;
using KamchatkaTravel.Domain.Interfaces;
using KamchatkaTravel.Domain.Tours;
using KamchatkaTravel.Domain.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamchatkaTravel.Domain.Shared.Tours;
using System.Diagnostics;
using System.Collections;

namespace KamchatkaTravel.Application.Tours
{
    public class TourService : ITourService
    {
        private readonly IMapper _mapper;
        private readonly ITourRepository _repository;

        public TourService(IMapper mapper, ITourRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IndexDto> Index()
        {

            IEnumerable<Tour> tours = await _repository.GetToursAsync();
            IEnumerable<Question> questions = await _repository.GetQuestionsAsync();
            IEnumerable<Review> reviews = await _repository.GetTop5ReviewsAsync();

            /*тут нужна проверка*/
            IndexDto response = new();
            response.Tours = _mapper.Map<IEnumerable<TourDto>>(tours);
            response.Questions = _mapper.Map<IEnumerable<QuestionDto>>(questions);
            response.Reviews = _mapper.Map<IEnumerable<ReviewDto>>(reviews);

            foreach(var t in response.Tours)
            {
                t.dayCount = tours.Where(x => x.Id == t.Id).Count();
            }

            return response;
        }

        public async Task<TourViewDto> GetTourInfo(Guid id)
        {
            TourViewDto response = new();
            var t = await _repository.GetTourByIdAsync(id);

            
            response.Tour = new TourDetailsDto();
            response.Tour.Id = t.Id;
            response.Tour.Name  = t.Name; 
            response.Tour.Tagline = t.Tagline; 
            response.Tour.LogoImage = t.LogoImage; 
            response.Tour.SeasonType = t.SeasonType; 
            response.Tour.NightType = t.NightType; 
            response.Tour.Price = t.Price; 
            response.Tour.Description = t.Description; 
            response.Tour.DescriptionImage = t.DescriptionImage;
            response.Tour.LinkEquipment = t.LinkEquipment;
            response.Tour.Views = _mapper.Map<List<View>, List<ViewDto>>(t.Views);
            response.Tour.Images = _mapper.Map<List<Image>, List<ImageDto>>(t.Images); 
            response.Tour.Days = _mapper.Map<List<Day>, List<DayDto>>(t.Days); 
            response.Tour.Includes = _mapper.Map<List<Include>, List<IncludeDto>>(t.Includes); 
            response.Tour.Questions = _mapper.Map<List<Question>, List<QuestionDto>>(t.Questions);

            //response.Tour = mapper.Map<Tour, TourDetailsDto>(await _repository.GetTourByIdAsync(id));
            return response;
        }

        public async Task CreateClientRequest(ClientRequestCreateDto clientRequest)
        {
            await _repository.CreateClientRequest(clientRequest.FirstName, clientRequest.Email, clientRequest.Phone, clientRequest.TourId);
        }
    }
}
