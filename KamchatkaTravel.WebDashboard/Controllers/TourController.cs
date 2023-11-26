using KamchatkaTravel.Application.Contracts.DTOs.DataDTOs;
using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Domain.Tours;
using KamchatkaTravel.EntityFrameworkCore.Migrations;
using KamchatkaTravel.WebDashboard.Models;
using KamchatkaTravel.WebDashboard.Models.ForAdd;
using KamchatkaTravel.WebDashboard.Models.ForAddView;
using KamchatkaTravel.WebDashboard.Models.ForEditView;
using KamchatkaTravel.WebDashboard.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KamchatkaTravel.WebDashboard.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    [Authorize(Roles = "SuperAdmin,Admin,User,Visitor")]
    public class TourController : Controller
    {
        //readonly IDataService _dataService;
        readonly IDashboardService _dashboardService;
        readonly IWebHostEnvironment _env;
        public TourController(IDashboardService dashboardService, IWebHostEnvironment env)
        {
            _dashboardService = dashboardService;
            _env = env;
        }

        #region Tour
        /// <summary>
        /// Получение представления для изменения тура
        /// А также для добавления и редактирования видов, дней, включено/невключено, вопросов, картинок и т.п.
        /// </summary>
        /// <param name="TourId"></param>
        /// <returns></returns>
        [Authorize(Roles = "SuperAdmin,Admin,User")]
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
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> EditTour(EditTourViewModel model)
        {
            var pathLogo = await MyFile.SaveFile(model.tour.LogoImageFile, _env.WebRootPath, ImageFolder.Get(Folder.Tour), model.tour.Name);
            model.tour.LogoImageUrl = pathLogo;
            var pathDescr = await MyFile.SaveFile(model.tour.DescriptionImageFile, _env.WebRootPath, ImageFolder.Get(Folder.Tour), model.tour.Name);
            model.tour.DescriptionImageUrl = pathDescr;
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
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> AddTourView()
        {
            return View("~/Views/Tours/AddTour.cshtml");
        }

        /// <summary>
        /// Создание тура, возвращает страницу со списком туров
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> AddTour(AddTourModel model)
        {
            await _dashboardService.CreateTourAsync(model.tour);
            return RedirectToAction("MainTour", "Home");
        }
        #endregion

        #region View
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> AddView(AddTourViewModel model)
        {
            // тут после добавления нужно идти на edit tour текущий(model.view.tourId)
            await _dashboardService.CreateTourViewAsync(model.view);
            return RedirectToAction("MainTour", "Home");
        }
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> GetAddView(Guid TourId)
        {
            AddTourViewModel model = new();
            model.view.TourId = TourId;
            return View("~/Views/Tours/AddView.cshtml", model);
        }
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> GetEditView(Guid ViewId)
        {
            EditViewModel model = new();
            model.view = await _dashboardService.GetViewByIdAsync(ViewId);
            //model.tour = await _dashboardService.GetTourByIdAsync(TourId);
            return View("~/Views/Tours/EditView.cshtml", model);
        }
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> EditView(EditViewModel model)
        {
            await _dashboardService.EditViewAsync(model.view);
            return RedirectToAction("GetEditView", new { ViewId = model.view.Id });
        }
        #endregion

        #region Image
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> AddImage(AddTourImageModel model)
        {
            await _dashboardService.CreateTourImageAsync(model.image);
            return RedirectToAction("MainTour", "Home");
        }

        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> GetAddImage(Guid TourId)
        {
            AddTourImageModel model = new();
            model.image.TourId = TourId;
            return View("~/Views/Tours/AddImage.cshtml", model);
        }

        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> GetEditImage(Guid ImageId)
        {
            EditImageModel model = new();
            model.image = await _dashboardService.GetImageByIdAsync(ImageId);
            return View("~/Views/Tours/EditImage.cshtml", model);   
        }

        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> EditImage(EditImageModel model)
        {
            await _dashboardService.EditImageAsync(model.image);
            return RedirectToAction("GetEditImage", new { ImageId = model.image.Id });
        }
        #endregion

        #region Day
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> AddDay(AddTourDayModel model)
        {
            var path = await MyFile.SaveFile(model.day.Img, _env.WebRootPath, ImageFolder.Get(Folder.Day), model.day.Name);
            model.day.ImageUrl = path;
            await _dashboardService.CreateTourDayAsync(model.day);
            return RedirectToAction("MainTour", "Home");
        }
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> GetAddDay(Guid TourId)
        {
            AddTourDayModel model = new();
            model.day.TourId = TourId;
            return View("~/Views/Tours/AddDay.cshtml", model);
        }
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> GetEditDay(Guid DayId)
        {
            EditDayModel model = new();
            model.day = await _dashboardService.GetDayByIdAsync(DayId);
            return View("~/Views/Tours/EditDay.cshtml", model);
        }

        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> EditDay(EditDayModel model)
        {
            var path = await MyFile.SaveFile(model.day.ImageFile, _env.WebRootPath, ImageFolder.Get(Folder.Day), model.day.Name);
            model.day.ImageUrl = path;
            await _dashboardService.EditDayAsync(model.day);
            return RedirectToAction("GetEditDay", new { DayId = model.day.Id });
        }
        #endregion

        #region Question
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> AddQuestion(AddTourQuestionModel model)
        {
            await _dashboardService.CreateTourQuestionAsync(model.question);
            return RedirectToAction("MainTour", "Home");
        }
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> GetAddQuestion(Guid TourId)
        {
            AddTourQuestionModel model = new();
            model.question.TourId = TourId;
            return View("~/Views/Tours/AddQuestion.cshtml", model);
        }
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> GetEditQuestion(Guid QuestionId)
        {
            EditQuestionModel model = new();
            model.question = await _dashboardService.GetQuestionByIdAsync(QuestionId);
            return View("~/Views/Tours/EditQuestion.cshtml", model);
        }

        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> EditQuestion(EditQuestionModel model)
        {
            await _dashboardService.EditQuestionAsync(model.question);
            return RedirectToAction("GetEditQuestion", new { QuestionId = model.question.Id });
        }
        #endregion

        #region Include
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> AddInclude(AddTourIncludeModel model)
        {
            await _dashboardService.CreateTourIncludeAsync(model.include);
            return RedirectToAction("MainTour", "Home");
        }
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> GetAddInclude(Guid TourId)
        {
            AddTourIncludeModel model = new();
            model.include.TourId = TourId;
            return View("~/Views/Tours/AddInclude.cshtml", model);
        }
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> GetEditInclude(Guid IncludeId)
        {
            EditIncludeModel model = new();
            model.include = await _dashboardService.GetIncludeByIdAsync(IncludeId);
            return View("~/Views/Tours/EditInclude.cshtml", model);
        }

        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> EditInclude(EditIncludeModel model)
        {
            await _dashboardService.EditIncludeAsync(model.include);
            return RedirectToAction("GetEditInclude", new { IncludeId = model.include.Id });
        }
        #endregion

    }
}
