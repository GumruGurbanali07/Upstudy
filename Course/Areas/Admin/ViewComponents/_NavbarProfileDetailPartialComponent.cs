using CourseApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Areas.Admin.ViewComponents
{
    public class _NavbarProfileDetailPartialComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        public _NavbarProfileDetailPartialComponent(UserManager<AppUser> userManager)
        {
            _userManager= userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name); 
            return View(values);
        }
    }
}
