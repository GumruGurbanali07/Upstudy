using CourseApp.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Blogs.Include(x => x.Teacher).Include(x => x.BlogCategory).Where(x => x.IsActive == true).ToList();
            return View(values);

        }

        public IActionResult BlogDetail(int id)
        {
            var values = _context.Blogs.Include(x=>x.BlogCategory).Include(x=>x.Teacher).FirstOrDefault(x=>x.BlogId==id);
            return View(values);
        }



    }
}
