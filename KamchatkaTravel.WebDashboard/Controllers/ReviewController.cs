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
    public class ReviewController : Controller
    {
        //readonly IDataService _dataService;
        readonly IDashboardService _dashboardService;
        readonly IWebHostEnvironment _env;
        public ReviewController(IDashboardService dashboardService, IWebHostEnvironment env)
        {
            _dashboardService = dashboardService;
            _env = env;
        }
        
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> AddReview(AddReviewModel model)
        {
            //сохраняем файл
            var path = await MyFile.SaveFile(model.review.LogoImg, _env.WebRootPath, ImageFolder.Get(Folder.Review), model.review.FirstName + model.review.LastName);
            //var path = _env.WebRootPath;
            //создаем отзыв
            model.review.LogoPath = path;
            await _dashboardService.CreateReviewAsync(model.review);
            return RedirectToAction("MainReviews", "Home");
        }
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> GetAddReview()
        {
            return View("~/Views/Reviews/AddReview.cshtml");
        }
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> GetEditReview(Guid ReviewId)
        {
            EditReviewModel model = new();
            model.review = await _dashboardService.GetReviewByIdAsync(ReviewId);
            return View("~/Views/Reviews/EditReview.cshtml", model);
        }

        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> EditReview(EditReviewModel model)
        {
            var path = await MyFile.SaveFile(model.review.ImageFile, _env.WebRootPath, ImageFolder.Get(Folder.Review), model.review.FirstName + model.review.LastName);
            model.review.LogoImageUrl = path;
            await _dashboardService.EditReviewAsync(model.review);
            return RedirectToAction("GetEditReview", new { ReviewId = model.review.Id });
        }
    }
}
