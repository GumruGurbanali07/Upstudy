using CourseApp.Models;
using System.ComponentModel.DataAnnotations;

namespace CourseApp.Areas.Admin.Models.CourseDTOs
{
    public class UpdateCourseDTO
    {
        [Required(ErrorMessage = "Course ID cannot be null")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid course ID")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Name cannot be null")]
        [StringLength(200, ErrorMessage = "Course name cannot be longer than 200 characters")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Price cannot be null")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Description cannot be null")]
        [StringLength(2000, ErrorMessage = "Course description cannot be longer than 2000 characters")]
        public string CourseDescription { get; set; }

        public bool IsActive { get; set; }

        public IFormFile? CourseImage { get; set; }

        [Required(ErrorMessage = "Category cannot be null")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid category ID")]
        public int CourseCategoryId { get; set; }

        [Required(ErrorMessage = "Teacher cannot be null")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid teacher ID")]
        public int TeacherId { get; set; }
    }
}
