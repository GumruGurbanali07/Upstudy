using System.ComponentModel.DataAnnotations;

namespace CourseApp.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentImage { get; set; }
        public string  StudentName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public List<CourseSubcribe> CourseSubcribes { get; set; }
    }
}
