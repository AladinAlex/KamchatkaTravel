using KamchatkaTravel.Application.Contracts.DTOs.DataDTOs;

namespace KamchatkaTravel.WebDashboard.Models
{
    public class AddTourViewModel
    {
        public CreateTourDto tour { get; set; }
        public CreateDayDto day { get; set; }
    }
}
