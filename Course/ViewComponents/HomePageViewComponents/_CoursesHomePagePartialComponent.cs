using CourseApp.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.ViewComponents.HomePageViewComponents
{
    public class _CoursesHomePagePartialComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public _CoursesHomePagePartialComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Coursess.Include(x => x.CourseCategory).Include(x => x.Teachers).OrderByDescending(x=>x.CourseId).Take(8).Where(x => x.IsActive == true).ToList();
            return View(values);
        }
    }
}
