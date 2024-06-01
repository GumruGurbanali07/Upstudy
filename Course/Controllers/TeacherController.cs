using CourseApp.Context;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        public TeacherController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index() 
        {
            var value = _context.Teachers.Where(x=>x.IsDeleted != true).ToList();
            return View(value);
        }

        public IActionResult TeacherDetail(int id)
        {
            var values = _context.Teachers.Find(id);
            return View(values);
        }
    }
}
