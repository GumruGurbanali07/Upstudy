using CourseApp.Context;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.ViewComponents.TeacherPageViewComponents
{
    public class SocialListCoursePagePartialComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public SocialListCoursePagePartialComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(int id)
        {
            var value = _context.TeacherSocials.Where(x => x.TeacherId == id).ToList();
            return View(value);
        }
    }
}
