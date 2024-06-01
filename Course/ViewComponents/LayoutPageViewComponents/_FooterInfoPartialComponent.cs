using CourseApp.Context;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.ViewComponents.LayoutPageViewComponents
{
    public class _FooterInfoPartialComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public _FooterInfoPartialComponent(AppDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.ContactDetails.FirstOrDefault();
            return View(values);
        }
    }
}
