using KamchatkaTravel.Application.Contracts.DTOs.DataDTOs;
using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Domain.Tours;
using KamchatkaTravel.EntityFrameworkCore.Migrations;
using KamchatkaTravel.WebDashboard.Models;
using KamchatkaTravel.WebDashboard.Models.ForAdd;
using KamchatkaTravel.WebDashboard.Models.ForAddView;
using KamchatkaTravel.WebDashboard.Models.ForEditView;
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
        public ReviewController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        
        [Authorize(Roles = "SuperAdmin,Admin,User")]
        public async Task<IActionResult> AddReview(AddReviewModel model)
        {
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
            await _dashboardService.EditReviewAsync(model.review);
            return RedirectToAction("GetEditReview", new { ReviewId = model.review.Id });
        }
    }
}
