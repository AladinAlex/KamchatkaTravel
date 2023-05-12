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
        private readonly ILogger<HomeController> _logger;
        private readonly ITourService _tourService;

        public HomeController(ILogger<HomeController> logger, ITourService tourService)
        {
            _logger = logger;
            _tourService = tourService;
        }

        public async Task<IActionResult> Index()
        {
            IndexDto result = await _tourService.Index();
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