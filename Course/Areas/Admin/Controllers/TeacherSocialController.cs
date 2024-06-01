using CourseApp.Context;
using CourseApp.Migrations;
using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherSocialController : Controller
    {
        private readonly AppDbContext _context;
        public TeacherSocialController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var values = _context.TeacherSocials.Where(x => x.TeacherId == id).ToList();
            ViewBag.TeacherName = _context.Teachers.Where(x => x.TeacherId == id).Select(x => x.TeacherName).FirstOrDefault();
            ViewBag.TeacherId = id;
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateSocial(int id)
        {
            ViewBag.SocialId = id;
            return View();
        }
        [HttpPost]
        public IActionResult CreateSocial(TeacherSocial teacherSocial)
        {
            _context.TeacherSocials.Add(teacherSocial);
            _context.SaveChanges();
            return LocalRedirect($"/Admin/TeacherSocial/Index/{teacherSocial.TeacherId}");
        }
        [HttpGet]
        public IActionResult UpdateSocial(int id)
        {
            ViewBag.TeacherId = _context.TeacherSocials.Where(x => x.TeacherSocialId == id).Select(x => x.TeacherId).FirstOrDefault();
            ViewBag.SocialId = id;
            var value = _context.TeacherSocials.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateSocial(TeacherSocial teacherSocial)
        {

            _context.TeacherSocials.Update(teacherSocial);
            _context.SaveChanges();
            return LocalRedirect($"/Admin/TeacherSocial/Index/{teacherSocial.TeacherId}");

        }

        public IActionResult DeleteSocial(int id)
        {
            var values = _context.TeacherSocials.Find(id);
            _context.TeacherSocials.Remove(values);
            _context.SaveChanges();
            return LocalRedirect($"/Admin/TeacherSocial/Index/{values.TeacherId}");
        }
    }
}
