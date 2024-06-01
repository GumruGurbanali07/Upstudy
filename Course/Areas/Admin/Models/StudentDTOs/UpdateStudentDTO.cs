using CourseApp.Models;
using System.ComponentModel.DataAnnotations;

namespace CourseApp.Areas.Admin.Models.StudentDTOs
{
    public class UpdateStudentDTO
    {
        [Required(ErrorMessage = "Section cannot be null")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Student ID")]
        public int StudentId { get; set; }

        public IFormFile? StudentImage { get; set; }

        [Required(ErrorMessage = "Section cannot be null")]
        [StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Section cannot be null")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1900", "12/31/2100", ErrorMessage = "BirthDate must be between 01/01/1900 and 12/31/2100")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Section cannot be null")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Section cannot be null")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; }

        public bool IsActive { get; set; }
    }
}
