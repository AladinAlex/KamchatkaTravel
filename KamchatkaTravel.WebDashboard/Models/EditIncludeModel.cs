using KamchatkaTravel.Application.Contracts.DTOs.TourDTOs;

namespace KamchatkaTravel.WebDashboard.Models
{
    public class EditIncludeModel
    {
        public IncludeModel include { get; set; } = new();
    }
}
