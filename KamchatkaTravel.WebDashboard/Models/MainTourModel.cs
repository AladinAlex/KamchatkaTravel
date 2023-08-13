using KamchatkaTravel.Application.Contracts.DTOs.TourDTOs;

namespace KamchatkaTravel.WebDashboard.Models
{
    public class MainTourModel
    {
        public IEnumerable<TourViewModel> tours  { get; set; }
    }
}
