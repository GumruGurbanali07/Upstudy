using System.ComponentModel.DataAnnotations;

namespace CourseApp.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public List<Courses> Courses { get; set; }
        public List<Blog> Blogs { get; set; }
        public bool IsActive { get; set; }
        public string TeacherImage { get; set; }
        public string Description { get; set; }
        public string Speciality { get; set; }
        public bool IsDeleted { get; set; }
        public List<TeacherSocial> TeacherSocials { get; set; }

    }
}
