using KamchatkaTravel.Application.Contracts.DTOs.DataDTOs;
using KamchatkaTravel.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KamchatkaTravel.WebDashboard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourController : Controller
    {
        readonly IDataService _dataService;
        public TourController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Route("CreateTour")]
        public async Task CreateTour([FromForm] CreateTourDto request)
        {
            await _dataService.CreateTour(request);
            //return View("/Views/Home/Index.cshtml");
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Route("CreateDay")]
        public async Task CreateDay([FromForm] CreateDayDto request)
        {
            await _dataService.CreateDay(request);
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("CreateQuestion")]
        public async Task CreateQuestion(CreateQuestionDto request)
        {
            await _dataService.CreateQuestion(request);
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("CreateReview")]
        public async Task CreateReview(CreateReviewDto request)
        {
            await _dataService.CreateReview(request);
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("CreateImage")]
        public async Task CreateImage(CreateImageDto request)
        {
            await _dataService.CreateImage(request);
        }


        [HttpPost]
        [Produces("application/json")]
        [Route("CreateInclude")]
        public async Task CreateInclude(CreateIncludeDto request)
        {
            await _dataService.CreateInclude(request);
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("CreateView")]
        public async Task CreateView(CreateViewDto request)
        {
            await _dataService.CreateView(request);
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("GetTours")]
        public async Task<GetToursResponse> GetTours()
        {
            var response = await _dataService.GetTours();
            return response;
        }
    }
}
