using System.ComponentModel.DataAnnotations;

namespace CourseApp.Models
{
    public class Testimonial
    {
        [Key]
        public int TestimonialId { get; set; }
        public string TestimonialImage  { get; set; }
        public string TestimonialName { get; set; }
        public string TestimonialDescription { get; set; }
        public bool IsActive { get; set; }


    }
}
