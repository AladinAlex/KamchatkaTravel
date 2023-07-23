using KamchatkaTravel.Application.Contracts.DTOs.DataDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.Interfaces
{
    public interface IDataService
    {
        Task CreateQuestion(CreateQuestionDto questionDto);
        Task CreateReview(CreateReviewDto reviewDto);
        Task CreateTour(CreateTourDto tourDto);
        Task CreateDay(CreateDayDto dayDto);
        Task CreateImage(CreateImageDto imageDto);
        Task CreateInclude(CreateIncludeDto incDto);
        Task CreateView(CreateViewDto viewDto);
        Task<GetToursResponse> GetTours();
    }
}
