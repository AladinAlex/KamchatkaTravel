using KamchatkaTravel.Application.Contracts.DTOs.DataDTOs;

namespace KamchatkaTravel.WebDashboard.Models.ForAddView
{
    public class AddTourIncludeModel
    {
        public CreateIncludeDto include { get; set; } = new();
    }
}
