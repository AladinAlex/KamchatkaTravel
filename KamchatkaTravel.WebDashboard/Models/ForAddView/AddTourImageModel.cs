using KamchatkaTravel.Application.Contracts.DTOs.DataDTOs;

namespace KamchatkaTravel.WebDashboard.Models.ForAddView
{
    public class AddTourImageModel
    {
        public CreateImageDto image { get; set; } = new();
    }
}
