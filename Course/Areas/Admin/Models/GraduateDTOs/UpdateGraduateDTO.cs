using System.ComponentModel.DataAnnotations;

namespace CourseApp.Areas.Admin.Models.GraduateDTOs
{
    public class UpdateGraduateDTO
    {
        [Required(ErrorMessage = "Section cannot be null")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Graduate ID")]
        public int GraduateId { get; set; }

        [Required(ErrorMessage = "Section cannot be null")]
        [StringLength(200, ErrorMessage = "Name cannot be longer than 200 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Section cannot be null")]
        [StringLength(2000, ErrorMessage = "Description cannot be longer than 2000 characters")]
        public string Description { get; set; }

        public IFormFile? Image { get; set; }

        [Required(ErrorMessage = "Section cannot be null")]
        [StringLength(500, ErrorMessage = "Comment cannot be longer than 500 characters")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Section cannot be null")]
        [StringLength(200, ErrorMessage = "Current Work cannot be longer than 200 characters")]
        public string CurrentWork { get; set; }

        public bool IsActive { get; set; }
    }
}
