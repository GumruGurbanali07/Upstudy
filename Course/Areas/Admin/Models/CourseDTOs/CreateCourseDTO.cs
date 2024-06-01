using System.ComponentModel.DataAnnotations;

namespace CourseApp.Areas.Admin.Models.CourseDTOs
{
    public class CreateCourseDTO
    {
        [Required(ErrorMessage = "Name can not null")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Price can not null")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Description can not null")]
        public string CourseDescription { get; set; }

        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Image can not null")]
        public IFormFile CourseImage { get; set; }
        [Required(ErrorMessage = "Category can not null")]
        public int CourseCategoryId { get; set; }

        [Required(ErrorMessage = "Teacher can not null")]
        public int TeacherId { get; set; }

    }
}
