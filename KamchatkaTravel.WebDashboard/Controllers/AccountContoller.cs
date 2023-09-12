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
        readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<IdentityPerson> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Login()
        {
            return View("Login");
        }

        public async Task Logout()
        {

        }
        public async Task SignIn(SignInModel model)
        {

        }
    }
}

