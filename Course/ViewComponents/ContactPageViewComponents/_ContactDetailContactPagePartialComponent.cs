using CourseApp.Context;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.ViewComponents.ContactPageViewComponents
{
    public class _ContactDetailContactPagePartialComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public _ContactDetailContactPagePartialComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values=_context.ContactDetails.FirstOrDefault();
            return View(values);
        }
    }
}
