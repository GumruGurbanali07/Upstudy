using CourseApp.DTOs;
using CourseApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    Name = registerDTO.Name,
                    Email = registerDTO.Email,
                    Surname = registerDTO.Surname,
                    Image = UploadFile(registerDTO.Image),
                    UserName = registerDTO.Username
                };
                var result = await _userManager.CreateAsync(appUser, registerDTO.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, "USER");
                    return RedirectToAction("Index", "Login");
                }
            }


            return View(registerDTO);
        }

        private string UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/ImagesFiles/RegisterImagesFiles/",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/ImagesFiles/RegisterImagesFiles/" + file.FileName;
        }
    }
}
