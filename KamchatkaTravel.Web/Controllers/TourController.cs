using KamchatkaTravel.Application.Contracts.DTOs;
using KamchatkaTravel.Application.Contracts.DTOs.ClientRequestDTOs;
using KamchatkaTravel.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KamchatkaTravel.Web.Controllers
{
    public class TourController : Controller
    {
        readonly ILogger<HomeController> _logger;
        readonly ITourService _tourService;
        readonly IConfiguration _config;

        public TourController(ILogger<HomeController> logger, ITourService tourService, IConfiguration config)
        {
            _logger = logger;
            _tourService = tourService;
            _config = config;
        }
        public async Task<IActionResult> Tour(Guid tourId)
        {
            TourViewDto result = await _tourService.GetTourInfo(tourId);
            foreach (var r in result.Tour.Days)
            {
                if (!string.IsNullOrWhiteSpace(r.ImageUrl))
                    r.ImageUrl = _config["ImageUrl"] + r.ImageUrl;
            }
            foreach (var r in result.Tour.Views)
            {
                if (!string.IsNullOrWhiteSpace(r.ImageUrl))
                    r.ImageUrl = _config["ImageUrl"] + r.ImageUrl;
            }
            result.Tour.Images = result.Tour.Images.OrderBy(x=> x.Ord).Take(8);
            foreach (var r in result.Tour.Images)
            {
                if (!string.IsNullOrWhiteSpace(r.ImageUrl))
                    r.ImageUrl = _config["ImageUrl"] + r.ImageUrl;
            }
            if (!string.IsNullOrWhiteSpace(result.Tour.LogoImageUrl))
                result.Tour.LogoImageUrl = _config["ImageUrl"] + result.Tour.LogoImageUrl;
            if (!string.IsNullOrWhiteSpace(result.Tour.DescriptionImageUrl))
                result.Tour.DescriptionImageUrl = _config["ImageUrl"] + result.Tour.DescriptionImageUrl;
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
