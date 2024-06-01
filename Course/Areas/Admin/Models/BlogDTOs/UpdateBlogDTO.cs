using System.ComponentModel.DataAnnotations;

namespace CourseApp.Areas.Admin.Models.BlogDTOs
{
    public class UpdateBlogDTO
    {
        [Required(ErrorMessage = "Blog ID cannot be null")]
        [Range(1, int.MaxValue, ErrorMessage = "Blog ID must be a positive integer")]
        public int BlogId { get; set; }

        [Required(ErrorMessage = "Blog title cannot be null")]
        [StringLength(200, ErrorMessage = "Blog title cannot be longer than 200 characters")]
        public string BlogTitle { get; set; }

        [Required(ErrorMessage = "Description cannot be null")]
        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters")]
        public string Description { get; set; }

        public bool IsActive { get; set; }

       
        public IFormFile? Image { get; set; }

        [Required(ErrorMessage = "Teacher ID cannot be null")]
        [Range(1, int.MaxValue, ErrorMessage = "Teacher ID must be a positive integer")]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Blog category ID cannot be null")]
        [Range(1, int.MaxValue, ErrorMessage = "Blog category ID must be a positive integer")]
        public int BlogCategoryId { get; set; }

        [Required(ErrorMessage = "Created date cannot be null")]
        public DateTime CreatedDate { get; set; }
    }
}
