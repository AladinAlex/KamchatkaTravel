using AutoMapper;
using KamchatkaTravel.Application.Contracts.DTOs.ClientRequestDTOs;
using KamchatkaTravel.Application.Contracts.DTOs.DataDTOs;
using KamchatkaTravel.Application.Contracts.DTOs.TourDTOs;
using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Domain.ClientRequests;
using KamchatkaTravel.Domain.Interfaces;
using KamchatkaTravel.Domain.Tours;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
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

        public async Task EditTourAsync(TourViewModel model)
        {
            var t = _mapper.Map<Tour>(model);
            t.LogoImage = WriteBytes(model.LogoImageFile);
            t.DescriptionImage = WriteBytes(model.DescriptionImageFile);
            await _dashboardRepository.UpdateTourAsync(t);
        }
        public async Task EditViewAsync(ViewModel model)
        {
            var v = _mapper.Map<View>(model);
            v.Image = WriteBytes(model.ImageFile);
            await _dashboardRepository.UpdateViewAsync(v);
        }

        public async Task CreateTourAsync(CreateTourDto model)
        {
            var t = _mapper.Map<Tour>(model);
            t.LogoImage = WriteBytes(model.LogoImg);
            t.DescriptionImage = WriteBytes(model.DescriptionImg);
            await _dashboardRepository.InsertTourAsync(t);
        }
        public async Task CreateTourViewAsync(CreateViewDto model)
        {
            var v = _mapper.Map<View>(model);
            v.Image = WriteBytes(model.Image);
            await _dashboardRepository.InsertViewAsync(v);
        }

        public async Task CreateTourImageAsync(CreateImageDto model)
        {
            var v = _mapper.Map<Image>(model);
            v.Img = WriteBytes(model.Image);
            await _dashboardRepository.InsertImageAsync(v);
        }

        public async Task<ViewModel> GetViewByIdAsync(Guid viewID)
        {
            var t = await _dashboardRepository.GetViewByIdAsync(viewID);
            var result = _mapper.Map<ViewModel>(t);
            return result;
        }

        private byte[] WriteBytes(IFormFile? ifile)
        {
            byte[] result = new byte[0];
            if (ifile == null)
                return result;

            string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(ifile.FileName);
            //string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", ImageName);
            if (ifile.Length > 0)
                using (var ms = new MemoryStream())
                {
                    ifile.CopyTo(ms);
                    result = ms.ToArray();
                }

            return result;
        }
    }
}
