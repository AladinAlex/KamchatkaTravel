using AutoMapper;
using KamchatkaTravel.Application.Contracts.DTOs.ClientRequestDTOs;
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
    }
}
