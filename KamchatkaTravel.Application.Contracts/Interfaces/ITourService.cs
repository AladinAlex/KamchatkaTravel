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
        Task<IndexDto> Index(bool withDefaultPictures = true);
        Task<TourViewDto> GetTourInfo(Guid id, bool withDefaultPictures = true);
        Task<TourViewDto> GetTourInfo(string TourName, bool withDefaultPictures = true);
        Task CreateClientRequest(ClientRequestCreateDto clientRequest);
    }
}
