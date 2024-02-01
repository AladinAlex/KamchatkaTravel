using KamchatkaTravel.Domain.ClientRequests;
using KamchatkaTravel.Domain.Reviews;
using KamchatkaTravel.Domain.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Domain.Interfaces
{
    public interface ITourRepository
    {
        //Task<Tour> InsertTourAsync(/*Поля*/);
        Task<Tour> GetTourByIdAsync(Guid Id);
        Task<Tour> GetTourByRouteNameAsync(string TourName);
        Task<IEnumerable<Tour>> GetToursAsync();
        Task<IEnumerable<Question>> GetQuestionsAsync();
        Task<IEnumerable<Review>> GetTop5ReviewsAsync();
        Task CreateClientRequest(string FirstName, string Email, string Phone, Guid? TourId);
    }
}
