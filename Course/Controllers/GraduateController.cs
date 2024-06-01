using CourseApp.Context;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class GraduateController : Controller
    {
        private readonly AppDbContext _context;
        public GraduateController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var values=_context.Graduates.Where(x=>x.IsActive==true).ToList();
            return View(values);
        }

    }
}
