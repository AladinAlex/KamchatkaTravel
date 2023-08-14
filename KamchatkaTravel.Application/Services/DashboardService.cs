using AutoMapper;
using KamchatkaTravel.Application.Contracts.DTOs.ClientRequestDTOs;
using KamchatkaTravel.Application.Contracts.DTOs.TourDTOs;
using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Domain.ClientRequests;
using KamchatkaTravel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Services
{
    public class DashboardService : IDashboardService
    {
        readonly IDashboardRepository _dashboardRepository;
        readonly IMapper _mapper;
        public DashboardService(IDashboardRepository dashboardRepository, IMapper mapper)
        {
            _dashboardRepository = dashboardRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientRequestViewModel>> GetClientRequestsAsync()
        {
            var result = await _dashboardRepository.SelectClientRequestAllAsync();
            return _mapper.Map<IEnumerable<ClientRequestViewModel>>(result);
        }

        public async Task ProcessRequest(Guid ClientRequestId)
        {
            await _dashboardRepository.UpdateProcessClientRequestAsync(ClientRequestId);
        }

        public async Task<ClientRequestViewModel> GetClientRequestByIdAsync(Guid ClientRequestId)
        {
            var cl = await _dashboardRepository.SelectClientRequestByIdAsync(ClientRequestId);
            ClientRequestViewModel result = _mapper.Map<ClientRequestViewModel>(cl);
            return result;
        }

        public async Task EditClientRequest(Guid ClientRequestId, string comment)
        {
            await _dashboardRepository.UpdateClientRequestByIdAsync(ClientRequestId, comment);
        }

        public async Task DeleteClientRequest(Guid ClientRequestId)
        {
            await _dashboardRepository.DeleteClientRequestByIdAsync(ClientRequestId);
        }
        public async Task<IEnumerable<TourViewModel>> GetToursAsync()
        {
            var t = await _dashboardRepository.SelectTourAllAsync();
            var result = _mapper.Map<IEnumerable<TourViewModel>>(t);
            return result;
        }
        public async Task<TourViewModel> GetTourByIdAsync(Guid tourID)
        {
            var t = await _dashboardRepository.GetTourByIdAsync(tourID);
            var result = _mapper.Map<TourViewModel>(t);
            return result;
        }
    }
}
