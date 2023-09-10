using KamchatkaTravel.Domain.ClientRequests;
using KamchatkaTravel.Domain.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Domain.Interfaces
{
    public interface IDashboardRepository
    {
        Task<IEnumerable<ClientRequest>> SelectClientRequestAllAsync();
        Task UpdateProcessClientRequestAsync(Guid Id);
        Task<ClientRequest> SelectClientRequestByIdAsync(Guid Id);
        Task UpdateClientRequestByIdAsync(Guid ClientRequestId, string comment);
        Task DeleteClientRequestByIdAsync(Guid ClientRequestId);
        Task<IEnumerable<Tour>> SelectTourAllAsync(bool? isVisible = null);
        Task<Tour> GetTourByIdAsync(Guid Id);
        Task UpdateTourAsync(Tour newTour);
        Task UpdateViewAsync(View newView);
        Task UpdateImageAsync(Image newImage);
        Task UpdateDayAsync(Day newDay);
        Task UpdateQuestionAsync(Question newQuestion);
        Task UpdateIncludeAsync(Include newInclude);
        Task InsertTourAsync(Tour tour);
        Task InsertViewAsync(View view);
        Task InsertImageAsync(Image image);
        Task InsertDayAsync(Day day);
        Task InsertQuestionAsync(Question question);
        Task InsertIncludeAsync(Include include);
        Task<View> GetViewByIdAsync(Guid Id);
        Task<Image> GetImageByIdAsync(Guid Id);
        Task<Day> GetDayByIdAsync(Guid Id);
        Task<Question> GetQuestionByIdAsync(Guid Id);
        Task<Include> GetIncludeByIdAsync(Guid Id);
    }
}
