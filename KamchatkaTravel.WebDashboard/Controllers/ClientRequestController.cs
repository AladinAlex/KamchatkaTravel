using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.WebDashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace KamchatkaTravel.WebDashboard.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,User,Visitor")]
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
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> ProcessRequest(Guid clientRequestID)
        {
            await _dashboardService.ProcessRequest(clientRequestID);
            return RedirectToAction("MainClientRequest", "Home");
        }

        [Authorize(Roles = "SuperAdmin,Admin,User")]
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
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> EditClientRequest(Guid clientRequestID, string comment)
        {
            await _dashboardService.EditClientRequest(clientRequestID, comment);
            return RedirectToAction("GetEditClientRequestView", new { clientRequestID = clientRequestID });
        }
        /// <summary>
        /// Удалить (скрыть заявку клиента)
        /// </summary>
        /// <param name="clientRequestID"></param>
        /// <returns></returns>
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> DeleteClientRequest(Guid clientRequestID)
        {
            await _dashboardService.DeleteClientRequest(clientRequestID);
            return RedirectToAction("MainClientRequest", "Home");
        }
    }
}
