using KamchatkaTravel.Application.Contracts.DTOs;
using KamchatkaTravel.Application.Contracts.DTOs.ClientRequestDTOs;
using KamchatkaTravel.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KamchatkaTravel.Web.Controllers
{
    public class TourController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITourService _tourService;
        public TourController(ILogger<HomeController> logger, ITourService tourService)
        {
            _logger = logger;
            _tourService = tourService;
        }
        public async Task<IActionResult> Tour(Guid tourId)
        {
            TourViewDto result = await _tourService.GetTourInfo(tourId);
            return View("Tour", result);
        }

        [HttpPost]
        [Route("/Tour/ClientRequest")]
        public async Task<IActionResult> CreateClientRequest([FromBody] ClientRequestCreateDto request)
        {
            await _tourService.CreateClientRequest(request);
            return Ok();
        }
    }
}
