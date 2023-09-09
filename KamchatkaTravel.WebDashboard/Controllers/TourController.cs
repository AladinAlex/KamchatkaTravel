using KamchatkaTravel.Application.Contracts.DTOs.DataDTOs;
using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.EntityFrameworkCore.Migrations;
using KamchatkaTravel.WebDashboard.Models;
using KamchatkaTravel.WebDashboard.Models.ForAdd;
using KamchatkaTravel.WebDashboard.Models.ForAddView;
using KamchatkaTravel.WebDashboard.Models.ForEditView;
using Microsoft.AspNetCore.Mvc;

namespace KamchatkaTravel.WebDashboard.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class TourController : Controller
    {
        //readonly IDataService _dataService;
        readonly IDashboardService _dashboardService;
        public TourController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        #region Tour
        /// <summary>
        /// Получение представления для изменения тура
        /// А также для добавления и редактирования видов, дней, включено/невключено, вопросов, картинок и т.п.
        /// </summary>
        /// <param name="TourId"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetEditTourView(Guid TourId)
        {
            EditTourViewModel model = new();
            model.tour = await _dashboardService.GetTourByIdAsync(TourId);
            //добавить виды, картинки, дни, вопросы, вкл/не вкл
            return View("~/Views/Tours/EditTour.cshtml", model);
        }

        /// <summary>
        /// Редактирование тура, получает новые данные, обновляет в базе
        /// Возвращает туже страницу
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IActionResult> EditTour(EditTourViewModel model)
        {
            await _dashboardService.EditTourAsync(model.tour);
            //return RedirectToAction("GetEditTourView", new { TourId = model.tour.Id });
            EditTourViewModel modelView = new();
            modelView.tour = await _dashboardService.GetTourByIdAsync(model.tour.Id);
            // Костыль: при RedirectToAction не переходит, временно сделал так
            return View("~/Views/Tours/EditTour.cshtml", modelView);
        }

        /// <summary>
        /// Получение представления для создания тура
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AddTourView()
        {
            return View("~/Views/Tours/AddTour.cshtml");
        }

        /// <summary>
        /// Создание тура, возвращает страницу со списком туров
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddTour(AddTourModel model)
        {
            await _dashboardService.CreateTourAsync(model.tour);
            return RedirectToAction("MainTour", "Home");
        }
        #endregion

        #region View
        public async Task<IActionResult> AddView(AddTourViewModel model)
        {
            // тут после добавления нужно идти на edit tour текущий(model.view.tourId)
            await _dashboardService.CreateTourViewAsync(model.view);
            return RedirectToAction("MainTour", "Home");
        }
        public async Task<IActionResult> GetAddView(Guid TourId)
        {
            AddTourViewModel model = new();
            model.view.TourId = TourId;
            return View("~/Views/Tours/AddView.cshtml", model);
        }
        public async Task<IActionResult> GetEditView(Guid ViewId)
        {
            EditViewModel model = new();
            model.view = await _dashboardService.GetViewByIdAsync(ViewId);
            //model.tour = await _dashboardService.GetTourByIdAsync(TourId);
            return View("~/Views/Tours/EditView.cshtml", model);
        }
        public async Task<IActionResult> EditView(EditViewModel model)
        {
            await _dashboardService.EditViewAsync(model.view);
            return RedirectToAction("GetEditView", new { ViewId = model.view.Id });
        }
        #endregion

        #region Image
        public async Task<IActionResult> AddImage(AddTourImageModel model)
        {
            await _dashboardService.CreateTourImageAsync(model.image);
            return RedirectToAction("MainTour", "Home");
        }

        public async Task<IActionResult> GetAddImage(Guid TourId)
        {
            AddTourImageModel model = new();
            model.image.TourId = TourId;
            return View("~/Views/Tours/AddImage.cshtml", model);
        }

        public async Task<IActionResult> GetEditImage(Guid ImageId)
        {
            EditImageModel model = new();
            model.image = await _dashboardService.GetImageByIdAsync(ImageId);
            return View("~/Views/Tours/EditImage.cshtml", model);   
        }

        public async Task<IActionResult> EditImage(EditImageModel model)
        {
            await _dashboardService.EditImageAsync(model.image);
            return RedirectToAction("GetEditImage", new { ImageId = model.image.Id });
        }
        #endregion

        #region Image
        public async Task<IActionResult> AddDay(AddTourDayModel model)
        {
            await _dashboardService.CreateTourDayAsync(model.day);
            return RedirectToAction("MainTour", "Home");
        }
        public async Task<IActionResult> GetAddDay(Guid TourId)
        {
            AddTourDayModel model = new();
            model.day.TourId = TourId;
            return View("~/Views/Tours/AddDay.cshtml", model);
        }
        public async Task<IActionResult> GetEditDay(Guid DayId)
        {
            EditDayModel model = new();
            model.day = await _dashboardService.GetDayByIdAsync(DayId);
            return View("~/Views/Tours/EditDay.cshtml", model);
        }

        public async Task<IActionResult> EditDay(EditDayModel model)
        {
            await _dashboardService.EditDayAsync(model.day);
            return RedirectToAction("GetEditDay", new { DayId = model.day.Id });
        }
        #endregion
    }
}
