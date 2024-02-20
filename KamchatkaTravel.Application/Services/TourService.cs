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
using KamchatkaTravel.Application.Utils;
using KamchatkaTravel.TelegramApi;
using KamchatkaTravel.TelegramApi.Models;
using KamchatkaTravel.Identity.Interfaces;

namespace KamchatkaTravel.Application.Services
{
    public class TourService : ITourService
    {
        private readonly IMapper _mapper;
        private readonly ITourRepository _repository;
        private readonly IIdentityRepository _identityRepository;
        readonly TelegramApiService _telegramApi;

        public TourService(IMapper mapper, ITourRepository repository, TelegramApiService telegramApi, IIdentityRepository identityRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _telegramApi = telegramApi;
            _identityRepository = identityRepository;
        }

        public async Task<IndexDto> Index(bool withDefaultPictures = true)
        {
            IEnumerable<Tour> tours = await _repository.GetToursAsync();
            IEnumerable<Question> questions = await _repository.GetQuestionsAsync();
            IEnumerable<Review> reviews = await _repository.GetTop5ReviewsAsync();

            /*тут нужна проверка*/
            IndexDto response = new();
            if (withDefaultPictures)
                response.PicturesLink = Tools.GetPictures();

            response.Tours = _mapper.Map<IEnumerable<TourDto>>(tours);
            response.Questions = _mapper.Map<IEnumerable<QuestionDto>>(questions);
            response.Reviews = _mapper.Map<IEnumerable<ReviewDto>>(reviews);

            foreach (var t in response.Tours)
            {
                t.dayCount = tours.Where(x => x.Id == t.Id).Count();
            }

            return response;
        }

        public async Task<TourViewDto> GetTourInfo(Guid id, bool withDefaultPictures = true)
        {
            var t = await _repository.GetTourByIdAsync(id);
            TourViewDto response = new()
            {
                Tour = _mapper.Map<TourDetailsDto>(t)
            };
            if (withDefaultPictures)
                response.PicturesLink = Tools.GetPictures();

            return response;
        }
        /// <summary>
        /// Получение тура по RouteName
        /// </summary>
        /// <param name="TourName">RouteName тура</param>
        /// <returns></returns>
        public async Task<TourViewDto> GetTourInfo(string TourName, bool withDefaultPictures = true)
        {
            var t = await _repository.GetTourByRouteNameAsync(TourName);
            TourViewDto response = new()
            {
                Tour = _mapper.Map<TourDetailsDto>(t)
            };
            if (withDefaultPictures)
                response.PicturesLink = Tools.GetPictures();

            return response;
        }

        public async Task CreateClientRequest(ClientRequestCreateDto clientRequest)
        {
            await _repository.CreateClientRequest(clientRequest.FirstName, clientRequest.Email, clientRequest.Phone, clientRequest.TourId);

            string message = "Новое обращение от " + clientRequest.FirstName + ". Телефон: " + clientRequest.Phone + ". Почта: " + clientRequest.Email;
            var chats = await _identityRepository.GetTelegramChatId();
            if (chats == null | chats?.Count < 1)
                return;

            List<Task> tasks = new List<Task>(chats.Count);
            foreach(int chat in chats)
            {
                tasks.Add(sendMesage(chat, message));
            }
        }

        private async Task sendMesage(int chat_id, string text)
        {
            bool End = false;
            int counter = 1;
            int mls = 500;
            TelegramServiceResponse response = new();
            while (counter <= 5 && !End)
            {
                response = await _telegramApi.SendMessage(chat_id, text);
                if (response != null && response.Success)
                    End = true;
                await Task.Delay(mls);
                counter++;
                mls += 1000;
            }

        }
    }
}
