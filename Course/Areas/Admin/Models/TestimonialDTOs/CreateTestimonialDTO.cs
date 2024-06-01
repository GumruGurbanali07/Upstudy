using System.ComponentModel.DataAnnotations;

namespace CourseApp.Areas.Admin.Models.TestimonialDTO
{
    public class CreateTestimonialDTO
    {
        [Required(ErrorMessage = "Testimonial image cannot be null")]
        public IFormFile TestimonialImage { get; set; }

        [Required(ErrorMessage = "Testimonial name cannot be null")]
        [StringLength(200, ErrorMessage = "Testimonial name cannot be longer than 200 characters")]
        public string TestimonialName { get; set; }

        [Required(ErrorMessage = "Testimonial description cannot be null")]
        [StringLength(2000, ErrorMessage = "Testimonial description cannot be longer than 2000 characters")]
        public string TestimonialDescription { get; set; }

        public bool IsActive { get; set; }
    }
}
