using CourseApp.Context;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.ViewComponents.AboutPageViewComponents
{
    public class _TeachersAboutPagePartialComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public _TeachersAboutPagePartialComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values=_context.Teachers.ToList();            
            return View(values);
        }
    }
}
