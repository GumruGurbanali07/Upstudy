using CourseApp.Context;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Abouts.FirstOrDefault();
            if (values != null)
            {
                return View(values);
            }
            else
            {
                return RedirectToAction("Indexx");
            }
        }

        public IActionResult Indexx()
        {
            return View();
        }
    }
}
