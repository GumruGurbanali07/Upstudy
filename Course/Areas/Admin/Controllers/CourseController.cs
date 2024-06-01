using CourseApp.Areas.Admin.Models.CourseDTOs;
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
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Coursess.Include(x => x.CourseCategory).Include(x => x.Teachers).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCourse()
        {
            //bu structure dropdown list-de teachers classinda olan datalarin siyahilanmasi ucun istifade olunur
            List<SelectListItem> teacherValues = (from x in _context.Teachers.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.TeacherName,
                                                      Value = x.TeacherId.ToString(),

                                                  }).ToList();
            ViewBag.Teachers = teacherValues;

            List<SelectListItem> categoryValues = (from x in _context.CourseCategories.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CourseCategoryName,
                                                       Value = x.CourseCategoryId.ToString(),

                                                   }).ToList();
            ViewBag.CourseCategory = categoryValues;

            return View();
        }

        [HttpPost]
        public IActionResult CreateCourse(CreateCourseDTO courseDto)
        {
            if (ModelState.IsValid)
            {
                Courses course = new Courses();
                course.CourseName = courseDto.CourseName;
                course.Price = courseDto.Price;
                course.CourseCategoryId = courseDto.CourseCategoryId;
                course.TeacherId = courseDto.TeacherId;
                course.CourseImage = UploadFile(courseDto.CourseImage);
                course.IsActive = false;
                course.CourseDescription = courseDto.CourseDescription;
                _context.Coursess.Add(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseDto);
        }

        [HttpGet]
        public IActionResult UpdateCourse(int id)
        {
            var courseValue = _context.Coursess.Find(id);

            List<SelectListItem> teacherValues = (from x in _context.Teachers.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.TeacherName,
                                                      Value = x.TeacherId.ToString(),

                                                  }).ToList();
            ViewBag.Teachers = teacherValues;

            List<SelectListItem> categoryValues = (from x in _context.CourseCategories.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CourseCategoryName,
                                                       Value = x.CourseCategoryId.ToString(),

                                                   }).ToList();
            ViewBag.CourseCategory = categoryValues;
            var getCourse = new UpdateCourseDTO
            {
                CourseId = courseValue.CourseId,
                CourseName = courseValue.CourseName,
                CourseDescription = courseValue.CourseDescription,
                CourseCategoryId = courseValue.CourseCategoryId,
                Price = courseValue.Price,
                IsActive = courseValue.IsActive,
                TeacherId = courseValue.TeacherId,

            };

            return View(getCourse);
        }
        [HttpPost]
        public IActionResult UpdateCourse(UpdateCourseDTO updateCourseDTO)
        {
            if (ModelState.IsValid)
            {
                var values = _context.Coursess.Find(updateCourseDTO.CourseId);
                values.CourseName = updateCourseDTO.CourseName;
                values.CourseDescription = updateCourseDTO.CourseDescription;
                values.CourseCategoryId = updateCourseDTO.CourseCategoryId;
                values.CourseId = updateCourseDTO.CourseId;
                values.CourseImage = updateCourseDTO.CourseImage != null ? UploadFile(updateCourseDTO.CourseImage) : values.CourseImage;
                values.Price = updateCourseDTO.Price;
                values.IsActive = values.IsActive;
                values.TeacherId = updateCourseDTO.TeacherId;
                values.CourseCategoryId = updateCourseDTO.CourseCategoryId;
                _context.Coursess.Update(values);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(updateCourseDTO);
        }

        public IActionResult DeleteCourse(int id)
        {
            var values = _context.Coursess.Find(id);
            _context.Coursess.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusToTrue(int id)
        {
            var values = _context.Coursess.Find(id);
            values.IsActive = true;
            _context.Coursess.Update(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatusToFalse(int id)
        {
            var values = _context.Coursess.Find(id);
            values.IsActive = false;
            _context.Coursess.Update(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        private string UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/ImagesFiles/CourseImagesFiles/",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/ImagesFiles/CourseImagesFiles/" + file.FileName;
        }
    }
}
