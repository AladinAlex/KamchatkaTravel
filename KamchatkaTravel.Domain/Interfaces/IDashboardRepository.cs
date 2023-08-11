using KamchatkaTravel.Domain.ClientRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Domain.Interfaces
{
    public interface IDashboardRepository
    {
        Task<IEnumerable<ClientRequest>> SelectClientRequestAllAsync();
        Task UpdateProcessClientRequestAsync(Guid Id);
        Task<ClientRequest> SelectClientRequestByIdAsync(Guid Id);
        Task UpdateClientRequestByIdAsync(Guid ClientRequestId, string comment);
    }
}
