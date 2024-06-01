using CourseApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.ViewComponents.LayoutPageViewComponents
{
    public class _ProfilNavbarPartialComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        public _ProfilNavbarPartialComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(values);
        }
    }
}
