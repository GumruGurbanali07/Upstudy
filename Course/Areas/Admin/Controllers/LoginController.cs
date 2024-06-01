using CourseApp.Areas.Admin.Models.AdminDTOs;
using CourseApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Areas.Admin.Controllers
{
    [Area("Admin")]
   
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AdminLoginDTO adminLoginDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(adminLoginDTO.Username, adminLoginDTO.Password, false, false);
            if (result.Succeeded)
            {
                return LocalRedirect("/Admin/Course/Index");
            }
            else
            {
                ModelState.AddModelError("Password", "Wrong password");
            }

            return View(adminLoginDTO);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
