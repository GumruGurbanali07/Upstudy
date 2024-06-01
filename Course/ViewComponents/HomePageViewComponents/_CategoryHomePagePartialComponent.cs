using CourseApp.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.ViewComponents.HomePageViewComponents
{
    public class _CategoryHomePagePartialComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public _CategoryHomePagePartialComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {

            var values = _context.CourseCategories.Where(x => x.IsActive == true).ToList();
            return View(values);
        }
    }
}
