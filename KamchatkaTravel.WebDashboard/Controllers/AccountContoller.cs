using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Identity.Models;
using KamchatkaTravel.WebDashboard.Controllers;
using KamchatkaTravel.WebDashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace KamchatkaTravel.WebDashboard.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
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

        [AllowAnonymous]
        public async Task<IActionResult> Login(string error = null)
        {
            if(!string.IsNullOrEmpty(error))
                ViewData["Error"] = error;

            return View("Login");
        }

        public async Task<IActionResult> Logout()
        {
            if (!string.IsNullOrEmpty(User?.Identity?.Name))
            {
                await _signInManager.SignOutAsync();
            }
            return Redirect("/");
        }

        [AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            if (!string.IsNullOrEmpty(User?.Identity?.Name))
            {
                await _signInManager.SignOutAsync();
            }

            var user = await _identityService.GetUserByLogin(model.Username);
            if (user == null)
                return RedirectToAction("Login", new { error = "Пользователь не найден!" });

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe,  false);

            if(result.IsNotAllowed)
                return RedirectToAction("Login", new { error = "Не верный пароль!" });

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

        public async Task<IActionResult> AddRole()
        {
            return View("AddRole");
        }

        public async Task<IActionResult> CreateRole(AddRoleModel model)
        {
            var result = await _identityService.AddRole(model.Name, model.NormalizedName);
            return View("Registration");
        }
        public async Task<IActionResult> AddUserRole(string error = null)
        {
            return View("AddUserRole", error);
        }

        public async Task<IActionResult> CreateUserRole(AddUserRoleModel model)
        {
            var user = await _identityService.GetUserByLogin(model.Username);
            if (user == null)
                return RedirectToAction("AddUserRole", new { error = "Пользователь не найден!" });

            var result = await _identityService.AddUserRole(user, model.RoleName);
            return RedirectToAction("Login");
        }
    }
}

