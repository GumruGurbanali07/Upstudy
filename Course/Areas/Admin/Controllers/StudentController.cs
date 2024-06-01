using CourseApp.Areas.Admin.Models.StudentDTOs;
using CourseApp.Context;
using CourseApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StudentController : Controller
    {

        private readonly AppDbContext _context;
        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Students.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateStudent()
        {


            return View();
        }

        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDTO studentDto)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student();
                student.StudentName = studentDto.StudentName;
                student.IsActive = false;
                student.StudentImage = UploadFile(studentDto.StudentImage);
                student.PhoneNumber = studentDto.PhoneNumber;
                student.Email = studentDto.Email;
                student.BirthDate = studentDto.BirthDate;
                var email = _context.Students.Where(x => x.Email == studentDto.Email).Select(x => x.Email).FirstOrDefault();
                var number = _context.Students.Where(x => x.PhoneNumber == studentDto.PhoneNumber).Select(x => x.PhoneNumber).FirstOrDefault();
                if (email != studentDto.PhoneNumber && number != studentDto.PhoneNumber)
                {
                    _context.Students.Add(student);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Error", "Phone number or email is already exist!");
                }
            }
            return View(studentDto);
        }

        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {
            var studentValue = _context.Students.Find(id);
            var getStudent = new UpdateStudentDTO
            {
                StudentName = studentValue.StudentName,
                IsActive = studentValue.IsActive,
                StudentId = studentValue.StudentId,
                BirthDate = studentValue.BirthDate,
                PhoneNumber = studentValue.PhoneNumber,
                Email = studentValue.Email,

            };

            return View(getStudent);
        }
        [HttpPost]
        public IActionResult UpdateStudent(UpdateStudentDTO updateStudentDTO)
        {
            if (ModelState.IsValid)
            {
                var values = _context.Students.Find(updateStudentDTO.StudentId);
                values.StudentName = updateStudentDTO.StudentName;
                values.StudentId = updateStudentDTO.StudentId;
                values.StudentImage = updateStudentDTO.StudentImage != null ? UploadFile(updateStudentDTO.StudentImage) : values.StudentImage;
                values.IsActive = values.IsActive;
                values.BirthDate = updateStudentDTO.BirthDate;
                values.PhoneNumber = updateStudentDTO.PhoneNumber;
                values.Email = updateStudentDTO.Email;
                var email = _context.Students.Where(x => x.Email == updateStudentDTO.Email).Select(x => x.Email).FirstOrDefault();
                var number = _context.Students.Where(x => x.PhoneNumber == updateStudentDTO.PhoneNumber).Select(x => x.PhoneNumber).FirstOrDefault();
                if (email != updateStudentDTO.PhoneNumber && number != updateStudentDTO.PhoneNumber)
                {
                    _context.Students.Update(values);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Error", "Phone number or email is already exist!");
                }

            }
            return View(updateStudentDTO);
        }

        public IActionResult DeleteStudent(int id)
        {
            var values = _context.Students.Find(id);
            _context.Students.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusToTrue(int id)
        {
            var values = _context.Students.Find(id);
            values.IsActive = true;
            _context.Students.Update(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatusToFalse(int id)
        {
            var values = _context.Students.Find(id);
            values.IsActive = false;
            _context.Students.Update(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        private string UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/ImagesFiles/StudentImagesFiles/",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/ImagesFiles/StudentImagesFiles/" + file.FileName;
        }
    }
}