using KamchatkaTravel.Application.Contracts.DTOs.DataDTOs;

namespace KamchatkaTravel.WebDashboard.Models.ForAddView
{
    public class AddTourDayModel
    {
        public CreateDayDto day { get; set; } = new();
    }
}
