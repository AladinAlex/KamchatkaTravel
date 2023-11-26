using KamchatkaTravel.Application.Contracts.DTOs;
using KamchatkaTravel.Application.Contracts.DTOs.ClientRequestDTOs;
using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KamchatkaTravel.Web.Controllers
{
    // Land in the ocean
    public class HomeController : Controller
    {
        readonly ILogger<HomeController> _logger;
        readonly ITourService _tourService;
        readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, ITourService tourService, IConfiguration config)
        {
            _logger = logger;
            _tourService = tourService;
            _config = config;
        }

        public async Task<IActionResult> Index()
        {
            IndexDto result = await _tourService.Index();
            foreach (var r in result.Reviews)
            {
                if (!string.IsNullOrWhiteSpace(r.LogoImageUrl))
                    r.LogoImageUrl = _config["ImageUrl"] + r.LogoImageUrl;
            }
            foreach (var r in result.Tours)
            {
                if (!string.IsNullOrWhiteSpace(r.LogoImageUrl))
                    r.LogoImageUrl = _config["ImageUrl"] + r.LogoImageUrl;
            }
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        [Route("/Home/ClientRequest")]
        public async Task<IActionResult> CreateClientRequest([FromBody] ClientRequestCreateDto request)
        {
            await _tourService.CreateClientRequest(request);
            return Ok();
        }
    }
}