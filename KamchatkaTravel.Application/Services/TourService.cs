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

namespace KamchatkaTravel.Application.Services
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

            foreach (var t in response.Tours)
            {
                t.dayCount = tours.Where(x => x.Id == t.Id).Count();
            }

            return response;
        }

        public async Task<TourViewDto> GetTourInfo(Guid id)
        {
            var t = await _repository.GetTourByIdAsync(id);
            TourViewDto response = new()
            {
                Tour = _mapper.Map<TourDetailsDto>(t)
            };

            return response;
        }

        public async Task CreateClientRequest(ClientRequestCreateDto clientRequest)
        {
            await _repository.CreateClientRequest(clientRequest.FirstName, clientRequest.Email, clientRequest.Phone, clientRequest.TourId);
        }
    }
}
