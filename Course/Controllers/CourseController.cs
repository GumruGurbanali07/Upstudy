using CourseApp.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        public CourseController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var values = _context.Coursess.Include(x => x.CourseCategory).Include(x => x.Teachers).Where(x => x.IsActive == true).ToList();
            return View(values);
        }
        public IActionResult CourseDetail(int id)
        {
            var values = _context.Coursess.Include(x => x.CourseCategory).Include(x => x.Teachers).FirstOrDefault(x => x.CourseId == id);
            var studentCount = _context.CourseSubcribes.Where(x => x.CourseId == id).Select(x => x.StudentId).Count();
            ViewBag.StudentCount = studentCount;
            return View(values);
        }
       
    }
}
