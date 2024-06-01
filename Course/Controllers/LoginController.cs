using CourseApp.Areas.Admin.Models.AdminDTOs;
using CourseApp.DTOs;
using CourseApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginDTO.Username, loginDTO.Password, false, false);
                if (result.Succeeded)
                {
                    return LocalRedirect("/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("Password", "Wrong password");
                }
            }

            return View(loginDTO);
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
