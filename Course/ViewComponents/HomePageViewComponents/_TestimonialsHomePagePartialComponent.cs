using CourseApp.Context;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.ViewComponents.HomePageViewComponents
{
    public class _TestimonialsHomePagePartialComponent : ViewComponent
    {

        private readonly AppDbContext _context;
        public _TestimonialsHomePagePartialComponent(AppDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Testimonials.Where(x=>x.IsActive==true).ToList();
            return View(values);
        }
    }
}
