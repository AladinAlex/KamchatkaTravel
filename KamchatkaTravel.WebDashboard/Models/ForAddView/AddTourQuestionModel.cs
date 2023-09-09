using KamchatkaTravel.Application.Contracts.DTOs.DataDTOs;

namespace KamchatkaTravel.WebDashboard.Models.ForAddView
{
    public class AddTourQuestionModel
    {
        public CreateQuestionDto question { get; set; } = new();
    }
}
