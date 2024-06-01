using CourseApp.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.ViewComponents.TeacherPageViewComponents
{
    public class TeacherDetailSocialPartialComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public TeacherDetailSocialPartialComponent(AppDbContext context)
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
