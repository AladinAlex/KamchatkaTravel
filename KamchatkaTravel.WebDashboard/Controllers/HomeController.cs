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

        public async Task<IActionResult> ClientRequest()
        {
            MainClientRequestModel model = new();
            model.clientRequests = await _dashboardService.GetClientRequests();
            return View("~/Views/ClientRequest/MainClientRequest.cshtml", model);
        }

        public async Task<IActionResult> MainTour()
        {
            return View("~/Views/Tours/MainTour.cshtml");
        }

        public async Task<IActionResult> MainClients()
        {
            return View("~/Views/Clients/MainClients.cshtml");
        }
    }
}