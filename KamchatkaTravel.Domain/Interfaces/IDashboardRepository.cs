﻿using KamchatkaTravel.Domain.ClientRequests;
using KamchatkaTravel.Domain.Tours;
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
        Task DeleteClientRequestByIdAsync(Guid ClientRequestId);
        Task<IEnumerable<Tour>> SelectTourAllAsync(bool? isVisible = null);
        Task<Tour> GetTourByIdAsync(Guid Id);
        Task UpdateTourAsync(Tour newTour);
    }
}
