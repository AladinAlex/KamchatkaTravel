using KamchatkaTravel.Application.Contracts.DTOs.DataDTOs;

namespace KamchatkaTravel.WebDashboard.Models
{
    public class TourViewModel
    {
        public CreateTourDto tour { get; set; }
        public CreateDayDto day { get; set; }
    }
}
