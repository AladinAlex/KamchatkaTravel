using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.WebDashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace KamchatkaTravel.WebDashboard.Controllers
{
    public class ClientRequestController : Controller
    {
        readonly IDashboardService _dashboardService;
        public ClientRequestController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        /// <summary>
        /// Изменение 
        /// </summary>
        /// <param name="clientRequestID">Id заявки</param>
        /// <returns></returns>
        public async Task<IActionResult> ProcessRequest(Guid clientRequestID)
        {
            await _dashboardService.ProcessRequest(clientRequestID);
            return RedirectToAction("MainClientRequest", "Home");
        }

        public async Task<IActionResult> GetEditClientRequestView(Guid clientRequestID)
        {
            EditClientRequestModel model = new();
            model.clientRequest = await _dashboardService.GetClientRequestByIdAsync(clientRequestID);
            return View("~/Views/ClientRequest/EditClientRequest.cshtml", model);
        }

        /// <summary>
        /// Редактирование заявки (пока что только коммент)
        /// </summary>
        /// <param name="id">ClientRequestId</param>
        /// <param name="comment">Комметарий</param>
        /// <returns></returns>
        public async Task<IActionResult> EditClientRequest(Guid clientRequestID, string comment)
        {
            await _dashboardService.EditClientRequest(clientRequestID, comment);
            return RedirectToAction("GetEditClientRequestView", new { clientRequestID = clientRequestID });
        }
    }
}
