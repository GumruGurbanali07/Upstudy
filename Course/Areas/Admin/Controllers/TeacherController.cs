using CourseApp.Areas.Admin.Models.TeacherDTOs;
using CourseApp.Context;
using CourseApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CourseApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TeacherController : Controller
    {

        private readonly AppDbContext _context;
        public TeacherController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Teachers.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTeacher()
        {
           return View();
        }

        [HttpPost]
        public IActionResult CreateTeacher(CreateTeacherDTO teacherDto)
        {
            if (ModelState.IsValid)
            {
                Teacher teacher = new Teacher();
                teacher.TeacherName= teacherDto.TeacherName;
                teacher.IsActive = false;
                teacher.TeacherImage = UploadFile(teacherDto.TeacherImage);
                teacher.Description = teacherDto.Description;
                teacher.Speciality = teacherDto.Speciality;
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacherDto);
        }

        [HttpGet]
        public IActionResult UpdateTeacher(int id)
        {
            var teacherValue = _context.Teachers.Find(id);           
            var getTeacher = new UpdateTeacherDTO
            {
                
                TeacherName = teacherValue.TeacherName,               
                IsActive = teacherValue.IsActive,
                TeacherId = teacherValue.TeacherId,
                Speciality = teacherValue.Speciality,
                Description = teacherValue.Description
            };

            return View(getTeacher);
        }
        [HttpPost]
        public IActionResult UpdateTeacher(UpdateTeacherDTO updateTeacherDTO)
        {
            if (ModelState.IsValid)
            {
                var values = _context.Teachers.Find(updateTeacherDTO.TeacherId);
                values.TeacherName = updateTeacherDTO.TeacherName;              
                values.TeacherId = updateTeacherDTO.TeacherId;
                values.TeacherImage = updateTeacherDTO.TeacherImage != null ? UploadFile(updateTeacherDTO.TeacherImage) : values.TeacherImage;               
                values.IsActive = values.IsActive;
                values.Speciality = updateTeacherDTO.Speciality;
                values.Description = updateTeacherDTO.Description;
                _context.Teachers.Update(values);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(updateTeacherDTO);
        }

        public IActionResult DeleteTeacher(int id)
        {
            var values = _context.Teachers.Find(id);
            _context.Teachers.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusToTrue(int id)
        {
            var values = _context.Teachers.Find(id);
            values.IsActive = true;
            _context.Teachers.Update(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatusToFalse(int id)
        {
            var values = _context.Teachers.Find(id);
            values.IsActive = false;
            _context.Teachers.Update(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        private string UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/ImagesFiles/TeacherImagesFiles/",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/ImagesFiles/TeacherImagesFiles/" + file.FileName;
        }
    }
}
