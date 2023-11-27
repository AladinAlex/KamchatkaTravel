using AutoMapper;
using KamchatkaTravel.Application.Contracts.DTOs.ClientRequestDTOs;
using KamchatkaTravel.Application.Contracts.DTOs.DataDTOs;
using KamchatkaTravel.Application.Contracts.DTOs.ReviewDTOs;
using KamchatkaTravel.Application.Contracts.DTOs.TourDTOs;
using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Domain.ClientRequests;
using KamchatkaTravel.Domain.Interfaces;
using KamchatkaTravel.Domain.Reviews;
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
        public async Task<IEnumerable<ReviewViewModel>> GetReviewsAsync()
        {
            var t = await _dashboardRepository.SelectReviewAllAsync();
            var result = _mapper.Map<IEnumerable<ReviewViewModel>>(t);
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
            //t.LogoImageUrl = WriteBytes(model.LogoImageFile);
            //t.DescriptionImageUrl = WriteBytes(model.DescriptionImageFile);
            await _dashboardRepository.UpdateTourAsync(t);
        }
        public async Task EditViewAsync(ViewModel model)
        {
            var v = _mapper.Map<View>(model);
            //v.ImageUrl = WriteBytes(model.ImageFile);
            await _dashboardRepository.UpdateViewAsync(v);
        }

        public async Task CreateTourAsync(CreateTourDto model)
        {
            var t = _mapper.Map<Tour>(model);
            //t.LogoImageUrl = WriteBytes(model.LogoImg);
            //t.DescriptionImageUrl = WriteBytes(model.DescriptionImg);
            await _dashboardRepository.InsertTourAsync(t);
        }
        public async Task CreateTourViewAsync(CreateViewDto model)
        {
            var v = _mapper.Map<View>(model);
            //v.ImageUrl = WriteBytes(model.Image);s
            await _dashboardRepository.InsertViewAsync(v);
        }

        public async Task CreateTourImageAsync(CreateImageDto model)
        {
            var v = _mapper.Map<Image>(model);
            v.Img = WriteBytes(model.Image);
            await _dashboardRepository.InsertImageAsync(v);
        }
        public async Task CreateTourDayAsync(CreateDayDto model)
        {
            var d = _mapper.Map<Day>(model);
            //d.ImageUrl = WriteBytes(model.Img);
            await _dashboardRepository.InsertDayAsync(d);
        }
        public async Task CreateReviewAsync(CreateReviewDto model)
        {
            var r = _mapper.Map<Review>(model);
            //передать сюда название 
            //r.LogoImage = WriteBytes(model.LogoImg);
            await _dashboardRepository.InsertReviewAsync(r);
        }
        public async Task CreateTourQuestionAsync(CreateQuestionDto model)
        {
            var q = _mapper.Map<Question>(model);
            await _dashboardRepository.InsertQuestionAsync(q);
        }
        public async Task CreateTourIncludeAsync(CreateIncludeDto model)
        {
            var i = _mapper.Map<Include>(model);
            await _dashboardRepository.InsertIncludeAsync(i);
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

        public async Task<ImageModel> GetImageByIdAsync(Guid ImageId)
        {
            var t = await _dashboardRepository.GetImageByIdAsync(ImageId);
            var result = _mapper.Map<ImageModel>(t);
            return result;
        }
        public async Task<DayModel> GetDayByIdAsync(Guid DayId)
        {
            var t = await _dashboardRepository.GetDayByIdAsync(DayId);
            var result = _mapper.Map<DayModel>(t);
            return result;
        }
        public async Task<ReviewModel> GetReviewByIdAsync(Guid ReviewId)
        {
            var t = await _dashboardRepository.GetReviewByIdAsync(ReviewId);
            var result = _mapper.Map<ReviewModel>(t);
            return result;
        }
        public async Task<QuestionModel> GetQuestionByIdAsync(Guid QuestionId)
        {
            var t = await _dashboardRepository.GetQuestionByIdAsync(QuestionId);
            var result = _mapper.Map<QuestionModel>(t);
            return result;
        }
        public async Task<IncludeModel> GetIncludeByIdAsync(Guid IncludeId)
        {
            var i = await _dashboardRepository.GetIncludeByIdAsync(IncludeId);
            var result = _mapper.Map<IncludeModel>(i);
            return result;
        }

        public async Task EditImageAsync(ImageModel model)
        {
            var i = _mapper.Map<Image>(model);
            i.Img = WriteBytes(model.ImgFile);
            await _dashboardRepository.UpdateImageAsync(i);
        }
        public async Task EditDayAsync(DayModel model)
        {
            var d = _mapper.Map<Day>(model);
            //d.ImageUrl = WriteBytes(model.ImageFile);
            await _dashboardRepository.UpdateDayAsync(d);
        }
        public async Task EditReviewAsync(ReviewModel model)
        {
            var r = _mapper.Map<Review>(model);
            //r.LogoImage = WriteBytes(model.ImageFile);
            await _dashboardRepository.UpdateReviewAsync(r);
        }
        public async Task EditQuestionAsync(QuestionModel model)
        {
            var q = _mapper.Map<Question>(model);
            await _dashboardRepository.UpdateQuestionAsync(q);
        }
        public async Task EditIncludeAsync(IncludeModel model)
        {
            var i = _mapper.Map<Include>(model);
            await _dashboardRepository.UpdateIncludeAsync(i);
        }
    }
}
