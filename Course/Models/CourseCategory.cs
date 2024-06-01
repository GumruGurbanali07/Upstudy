using System.ComponentModel.DataAnnotations;

namespace CourseApp.Models
{
    public class CourseCategory
    {
        [Key]
        public int CourseCategoryId { get; set; }
        public string Icon { get; set; }
        public string CourseCategoryName { get; set; }
        public bool IsActive { get; set; }
        public List<Courses> Courses { get; set; }
        
    }
}
