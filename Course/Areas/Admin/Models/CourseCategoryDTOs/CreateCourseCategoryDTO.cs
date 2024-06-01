using System.ComponentModel.DataAnnotations;

namespace CourseApp.Areas.Admin.Models.CourseCategoryDTOs
{
    public class CreateCourseCategoryDTO
    {
        [Required(ErrorMessage = "Course category name cannot be null")]
        [StringLength(200, ErrorMessage = "Course category name cannot be longer than 200 characters")]
        public string CourseCategoryName { get; set; }

        [Required(ErrorMessage = "Icon cannot be null")]
        [StringLength(50, ErrorMessage = "Icon cannot be longer than 50 characters")]
        public string Icon { get; set; }

        public bool IsActive { get; set; }
    }
}