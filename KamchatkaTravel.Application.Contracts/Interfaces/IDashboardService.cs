using KamchatkaTravel.Application.Contracts.DTOs.ClientRequestDTOs;
using KamchatkaTravel.Application.Contracts.DTOs.TourDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.Interfaces
{
    public interface IDashboardService
    {
        Task<IEnumerable<ClientRequestViewModel>> GetClientRequestsAsync();
        Task ProcessRequest(Guid id);
        Task<ClientRequestViewModel> GetClientRequestByIdAsync(Guid ClientRequestId);
        Task EditClientRequest(Guid ClientRequestId, string comment);
        Task DeleteClientRequest(Guid ClientRequestId);
        Task<IEnumerable<TourViewModel>> GetToursAsync();
        Task<TourViewModel> GetTourByIdAsync(Guid tourID);
        Task EditTourAsync(TourViewModel model);
    }
}
