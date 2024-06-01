using CourseApp.Models;
using System.ComponentModel.DataAnnotations;

namespace CourseApp.Areas.Admin.Models.TeacherDTOs
{
    public class CreateTeacherDTO
    {
        [Required(ErrorMessage = "Teacher name cannot be null")]
        [StringLength(100, ErrorMessage = "Teacher name cannot be longer than 100 characters")]
        public string TeacherName { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Teacher image cannot be null")]
        public IFormFile TeacherImage { get; set; }

        [Required(ErrorMessage = "Description cannot be null")]
        [StringLength(2000, ErrorMessage = "Description cannot be longer than 2000 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Speciality cannot be null")]
        [StringLength(100, ErrorMessage = "Speciality cannot be longer than 100 characters")]
        public string Speciality { get; set; }
    }
}
