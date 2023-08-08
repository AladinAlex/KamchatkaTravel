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

        public async Task<IEnumerable<ClientRequestViewModel>> GetClientRequests()
        {
            var result = await _dashboardRepository.SelectClientRequestAll();
            return _mapper.Map<IEnumerable<ClientRequestViewModel>>(result);
        }
    }
}
