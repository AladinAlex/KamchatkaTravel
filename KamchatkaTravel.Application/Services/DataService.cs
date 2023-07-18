using AutoMapper;
using KamchatkaTravel.Application.Contracts.DTOs.DataDTOs;
using KamchatkaTravel.Application.Contracts.DTOs.TourDTOs;
using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Domain.Interfaces;
using KamchatkaTravel.Domain.Reviews;
using KamchatkaTravel.Domain.Tours;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Image = KamchatkaTravel.Domain.Tours.Image;

namespace KamchatkaTravel.Application.Services
{
    public class DataService : IDataService
    {
        private readonly IMapper _mapper;
        private readonly IDataRepository _repository;

        public DataService(IMapper mapper, IDataRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task CreateQuestion(CreateQuestionDto questionDto)
        {
            var q = _mapper.Map<Question>(questionDto);
            await _repository.InsertQuestion(q);
        }

        public async Task CreateReview(CreateReviewDto reviewDto)
        {
            var r = _mapper.Map<Review>(reviewDto);
            await _repository.InsertReview(r);
        }

        public async Task CreateTour(CreateTourDto tourDto)
        {
            var t = _mapper.Map<Tour>(tourDto);
            t.LogoImage = await WriteBytes(tourDto.Logos);
            t.DescriptionImage = await WriteBytes(tourDto.DescriptionImages);

            await _repository.InsertTour(t);
        }
        public async Task CreateDay(CreateDayDto dayDto)
        {
            var d = _mapper.Map<Day>(dayDto);
            await _repository.InsertDay(d);
        }

        public async Task CreateImage(CreateImageDto imageDto)
        {
            var i = _mapper.Map<Image>(imageDto);
            await _repository.InsertImage(i);
        }

        public async Task CreateInclude(CreateIncludeDto incDto)
        {
            var i = _mapper.Map<Include>(incDto);
            await _repository.InsertInclude(i);
        }

        public async Task CreateView(CreateViewDto viewDto)
        {
            var v = _mapper.Map<View>(viewDto);
            await _repository.InsertView(v);
        }
        private async Task<byte[]> WriteBytes(IFormFile ifile)
        {
            byte[] result = new byte[0];
            //return result;

            string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(ifile.FileName);
            string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", ImageName);

            //result = 
            if(ifile.Length > 0)
                using (var ms = new MemoryStream())
                {
                    ifile.CopyTo(ms);
                    result = ms.ToArray();
                }
            System.IO.DirectoryInfo di = new DirectoryInfo(SavePath);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            return result;
        }

    }
}
