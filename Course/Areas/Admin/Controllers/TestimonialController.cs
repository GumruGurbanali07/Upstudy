using CourseApp.Areas.Admin.Models.TestimonialDTO;
using CourseApp.Areas.Admin.Models.TestimonialDTOs;
using CourseApp.Context;
using CourseApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {

        private readonly AppDbContext _context;
        public TestimonialController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Testimonials.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {


            return View();
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDTO testimonialDto)
        {
            if (ModelState.IsValid)
            {
                Testimonial testimonial = new Testimonial();
                testimonial.TestimonialName = testimonialDto.TestimonialName;
                testimonial.IsActive = false;
                testimonial.TestimonialImage = UploadFile(testimonialDto.TestimonialImage);
                testimonial.TestimonialDescription = testimonialDto.TestimonialDescription;
                _context.Testimonials.Add(testimonial);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testimonialDto);
        }

        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var TestimonialValue = _context.Testimonials.Find(id);
            var getTestimonial = new UpdateTestimonialDTO
            {
                TestimonialName = TestimonialValue.TestimonialName,
                IsActive = TestimonialValue.IsActive,
                TestimonialId = TestimonialValue.TestimonialId,
                TestimonialDescription=TestimonialValue.TestimonialDescription,
            };

            return View(getTestimonial);
        }
        [HttpPost]
        public IActionResult UpdateTestimonial(UpdateTestimonialDTO updateTestimonialDTO)
        {
            if (ModelState.IsValid)
            {
                var values = _context.Testimonials.Find(updateTestimonialDTO.TestimonialId);
                values.TestimonialName = updateTestimonialDTO.TestimonialName;
                values.TestimonialId = updateTestimonialDTO.TestimonialId;
                values.TestimonialImage = updateTestimonialDTO.TestimonialImage != null ? UploadFile(updateTestimonialDTO.TestimonialImage) : values.TestimonialImage;
                values.TestimonialDescription = updateTestimonialDTO.TestimonialDescription;
                values.IsActive = values.IsActive;
                _context.Testimonials.Update(values);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(updateTestimonialDTO);
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var values = _context.Testimonials.Find(id);
            _context.Testimonials.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusToTrue(int id)
        {
            var values = _context.Testimonials.Find(id);
            values.IsActive = true;
            _context.Testimonials.Update(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatusToFalse(int id)
        {
            var values = _context.Testimonials.Find(id);
            values.IsActive = false;
            _context.Testimonials.Update(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        private string UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/ImagesFiles/TestimonialImagesFiles/",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/ImagesFiles/TestimonialImagesFiles/" + file.FileName;
        }
    }
}