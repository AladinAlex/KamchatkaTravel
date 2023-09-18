using KamchatkaTravel.Application.Contracts.DTOs.DataDTOs;

namespace KamchatkaTravel.WebDashboard.Models.ForAddView
{
    public class AddReviewModel
    {
        public CreateReviewDto review { get; set; } = new();
    }
}
