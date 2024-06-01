using System.ComponentModel.DataAnnotations;

namespace CourseApp.Models
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public decimal Price { get; set; }
        public string CourseDescription { get; set; }
        public bool IsActive { get; set; }
        public string CourseImage { get; set; }

        public int CourseCategoryId { get; set; }
        public CourseCategory CourseCategory { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teachers { get; set; }

        public List<CourseSubcribe> CourseSubcribes { get; set; }

    }
}
