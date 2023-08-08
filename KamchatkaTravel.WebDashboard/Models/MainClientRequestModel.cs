using KamchatkaTravel.Application.Contracts.DTOs.ClientRequestDTOs;
using KamchatkaTravel.Domain.ClientRequests;

namespace KamchatkaTravel.WebDashboard.Models
{
    public class MainClientRequestModel
    {
        public IEnumerable<ClientRequestViewModel> clientRequests { get; set; }
    }
}
