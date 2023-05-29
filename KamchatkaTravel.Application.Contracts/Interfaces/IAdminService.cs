using KamchatkaTravel.Application.Contracts.DTOs.AdminDto;
using KamchatkaTravel.Application.Contracts.DTOs.ClientRequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.Interfaces
{
    public interface IAdminService
    {
        Task CreateQuestion(CreateQuestionDto questionDto);
        Task CreateReview(CreateReviewDto reviewDto);

    }
}
