using KamchatkaTravel.Application.Contracts.DTOs.AdminDto;
using KamchatkaTravel.Application.Contracts.DTOs.ClientRequestDTOs;
using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Application.Tours;
using KamchatkaTravel.EntityFrameworkCore.Admin;
using Microsoft.AspNetCore.Mvc;

namespace KamchatkaTravel.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IAdminService _adminService;

        public AdminController(ILogger<AdminController> logger, IAdminService adminService)
        {
            _logger = logger;
            _adminService = adminService;
        }

        [HttpPost]
        [Route("/admin/CreateReview")]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto request)
        {
            await _adminService.CreateReview(request);
            return Ok();
        }

        [HttpPost]
        [Route("/admin/CreateQuestion")]
        public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionDto request)
        {
            await _adminService.CreateQuestion(request);
            return Ok();
        }
    }
}
