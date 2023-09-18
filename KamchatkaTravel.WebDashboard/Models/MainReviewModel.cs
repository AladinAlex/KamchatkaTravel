using KamchatkaTravel.Application.Contracts.DTOs.ReviewDTOs;

namespace KamchatkaTravel.WebDashboard.Models
{
    public class MainReviewModel
    {

        public IEnumerable<ReviewViewModel> reviews { get; set; } = new List<ReviewViewModel>();

    }
}
