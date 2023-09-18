using KamchatkaTravel.Application.Contracts.DTOs.ClientRequestDTOs;
using KamchatkaTravel.Application.Contracts.DTOs.DataDTOs;
using KamchatkaTravel.Application.Contracts.DTOs.ReviewDTOs;
using KamchatkaTravel.Application.Contracts.DTOs.TourDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.Interfaces
{
    public interface IDashboardService
    {
        Task<IEnumerable<ClientRequestViewModel>> GetClientRequestsAsync();
        Task ProcessRequest(Guid id);
        Task<ClientRequestViewModel> GetClientRequestByIdAsync(Guid ClientRequestId);
        Task EditClientRequest(Guid ClientRequestId, string comment);
        Task DeleteClientRequest(Guid ClientRequestId);
        Task<IEnumerable<TourViewModel>> GetToursAsync();
        Task<IEnumerable<ReviewViewModel>> GetReviewsAsync();
        Task<TourViewModel> GetTourByIdAsync(Guid tourId);
        Task EditTourAsync(TourViewModel model);
        Task EditViewAsync(ViewModel model);
        Task EditImageAsync(ImageModel model);
        Task EditDayAsync(DayModel model);
        Task EditReviewAsync(ReviewModel model);
        Task EditQuestionAsync(QuestionModel model);
        Task EditIncludeAsync(IncludeModel model);
        Task CreateTourAsync(CreateTourDto model);
        Task CreateTourViewAsync(CreateViewDto model);
        Task CreateTourImageAsync(CreateImageDto model);
        Task CreateTourDayAsync(CreateDayDto model);
        Task CreateReviewAsync(CreateReviewDto model);
        Task CreateTourQuestionAsync(CreateQuestionDto model);
        Task CreateTourIncludeAsync(CreateIncludeDto model);
        Task<ViewModel> GetViewByIdAsync(Guid viewId);
        Task<ImageModel> GetImageByIdAsync(Guid ImageId);
        Task<DayModel> GetDayByIdAsync(Guid DayId);
        Task<ReviewModel> GetReviewByIdAsync(Guid ReviewId);
        Task<QuestionModel> GetQuestionByIdAsync(Guid QuestionId);
        Task<IncludeModel> GetIncludeByIdAsync(Guid IncludeId);
    }
}
