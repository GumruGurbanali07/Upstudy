using CourseApp.Context;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.ViewComponents.HomePageViewComponents
{
    public class _AboutHomePagePartialComponent : ViewComponent
    {

        private readonly AppDbContext _context;
        public _AboutHomePagePartialComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Abouts.FirstOrDefault();
            if (values != null)
            {
                return View(values);
            }
            else
            {
                return Content("Not Content");
            }
        }
    }
}
