using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Identity.Models;
using KamchatkaTravel.WebDashboard.Controllers;
using KamchatkaTravel.WebDashboard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KamchatkaTravel.WebDashboard.Controllers
{
    public class AccountController : Controller
    {
        readonly UserManager<IdentityPerson> _userManager;
        readonly SignInManager<IdentityPerson> _signInManager;
        readonly RoleManager<IdentityRole> _roleManager;
        readonly IIdentityService _identityService;
        public AccountController(UserManager<IdentityPerson> userManager, RoleManager<IdentityRole> roleManager, IIdentityService identityService, SignInManager<IdentityPerson> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _identityService = identityService;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Login(string error = null)
        {
            if(!string.IsNullOrEmpty(error))
                ViewData["Error"] = error;

            return View("Login");
        }

        public async Task Logout()
        {

        }
        public async Task<IActionResult> SignIn(SignInModel model)
        {


            if (!string.IsNullOrEmpty(User?.Identity?.Name))
            {
                await _signInManager.SignOutAsync();
            }

            var user = await _identityService.GetUserByLogin(model.Username);
            if (user == null)
                return RedirectToAction("Login", new { error = "Пользователь не найден!" });

            //await _signInManager.SignInAsync();

            return RedirectToAction("Login");
        }

        [HttpPost("CreatePerson")]
        public async Task<IActionResult> CreatePerson(CreatePersonModel request)
        {
            var result = await _identityService.AddUser(request.Name, request.Username, request.Password, request.Surname, request.Comment, request.Email);
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Registration()
        {
            return View("Registration");
        }
    }
}

