using KamchatkaTravel.Application.Contracts.DTOs.ClientRequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.Interfaces
{
    public interface IDashboardService
    {
        Task<IEnumerable<ClientRequestViewModel>> GetClientRequests();
    }
}
