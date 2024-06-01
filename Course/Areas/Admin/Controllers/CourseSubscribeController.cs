using CourseApp.Context;
using CourseApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CourseSubscribeController : Controller
    {
        private readonly AppDbContext _context;
        public CourseSubscribeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var values = _context.CourseSubcribes.Include(x => x.Course).ToList().DistinctBy(x => x.Course.CourseName).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateSubscriber()
        {
            List<SelectListItem> studentValues = (from x in _context.Students.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.StudentName,
                                                      Value = x.StudentId.ToString(),

                                                  }).ToList();
            ViewBag.Students = studentValues;

            List<SelectListItem> courseValues = (from x in _context.Coursess.ToList()
                                                 
                                                 select new SelectListItem
                                                  {
                                                      Text = x.CourseName,
                                                      Value = x.CourseId.ToString(),

                                                  }).ToList();
            ViewBag.Courses = courseValues;
            return View();
        }
        [HttpPost]
        public IActionResult CreateSubscriber(CourseSubcribe courseSubcribe)
        {
            _context.CourseSubcribes.Add(courseSubcribe);
            _context.SaveChanges();
            return LocalRedirect("/Admin/CourseSubscribe/StudentListByCourse/" + courseSubcribe.CourseId);
        }

        public IActionResult StudentListByCourse(int id)
        {
            var courseName=_context.Coursess.Where(x=>x.CourseId == id).Select(x=>x.CourseName).FirstOrDefault();
            ViewBag.CourseName = courseName;
            var values = _context.CourseSubcribes.Where(x => x.CourseId == id).Include(x => x.Student).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSubscriber(int id)
        {
            List<SelectListItem> studentValues = (from x in _context.Students
                                                  .Where(s => s.CourseSubcribes.All(cs => cs.CourseId != id))
                                                  select new SelectListItem
                                                  {
                                                      Text = x.StudentName,
                                                      Value = x.StudentId.ToString(),

                                                  }).ToList();
            ViewBag.Students = studentValues;
            ViewBag.CourseId = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddSubscriber(CourseSubcribe courseSubcribe)
        {
            _context.CourseSubcribes.Add(courseSubcribe);
            _context.SaveChanges();
            return LocalRedirect("/Admin/CourseSubscribe/StudentListByCourse/" + courseSubcribe.CourseId);
        }
        public IActionResult DeleteSubscriber(int id)
        {
            var values = _context.CourseSubcribes.Find(id);
            _context.CourseSubcribes.Remove(values);
            _context.SaveChanges();
            return LocalRedirect("/Admin/CourseSubscribe/StudentListByCourse/" + values.CourseId);
        }
    }
}

