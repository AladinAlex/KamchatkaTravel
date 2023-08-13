using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Application.Services;
using KamchatkaTravel.WebDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KamchatkaTravel.WebDashboard.Controllers
{
    public class HomeController : Controller
    {
        readonly IDashboardService _dashboardService;
        public HomeController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> MainClientRequest()
        {
            MainClientRequestModel model = new();
            model.clientRequests = await _dashboardService.GetClientRequestsAsync();
            return View("~/Views/ClientRequest/MainClientRequest.cshtml", model);
        }

        public async Task<IActionResult> MainTour()
        {
            MainTourModel model = new();
            model.tours = await _dashboardService.GetToursAsync();
            return View("~/Views/Tours/MainTour.cshtml", model);
        }

        public async Task<IActionResult> MainClients()
        {
            return View("~/Views/Clients/MainClients.cshtml");
        }
    }
}