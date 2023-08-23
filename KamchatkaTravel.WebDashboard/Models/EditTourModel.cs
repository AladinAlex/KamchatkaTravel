using KamchatkaTravel.Application.Contracts.DTOs.TourDTOs;

namespace KamchatkaTravel.WebDashboard.Models
{
    public class EditTourModel
    {
        public TourViewModel tour { get; set; }
        public List<ViewModel> views { get; set; }
    }
}
