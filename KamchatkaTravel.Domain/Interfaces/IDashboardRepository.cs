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
        Task<IEnumerable<ClientRequest>> SelectClientRequestAll();
    }
}
