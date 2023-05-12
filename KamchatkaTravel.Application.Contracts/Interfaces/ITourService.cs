using KamchatkaTravel.Application.Contracts.DTOs;
using KamchatkaTravel.Application.Contracts.DTOs.ClientRequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.Interfaces
{
    public interface ITourService
    {
        Task<IndexDto> Index();
        Task<TourViewDto> GetTourInfo(Guid id);
        Task CreateClientRequest(ClientRequestCreateDto clientRequest);
    }
}
