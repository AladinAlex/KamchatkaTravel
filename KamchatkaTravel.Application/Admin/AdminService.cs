using AutoMapper;
using KamchatkaTravel.Application.Contracts.DTOs.AdminDto;
using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Domain.Interfaces;
using KamchatkaTravel.Domain.Reviews;
using KamchatkaTravel.Domain.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Admin
{
    public class AdminService : IAdminService
    {
        private readonly IMapper _mapper;
        private readonly IAdminRepository _repository;

        public AdminService(IMapper mapper, IAdminRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task CreateQuestion(CreateQuestionDto questionDto)
        {
            var q = _mapper.Map<Question>(questionDto);
            await _repository.CreateQuestion(q);
        }

        public async Task CreateReview(CreateReviewDto reviewDto)
        {
            var r = _mapper.Map<Review>(reviewDto);
            await _repository.CreateReview(r);
        }
    }
}
