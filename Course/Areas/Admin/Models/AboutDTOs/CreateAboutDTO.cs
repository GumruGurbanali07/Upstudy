using System.ComponentModel.DataAnnotations;

namespace CourseApp.Areas.Admin.Models.AboutDTOs
{
    public class CreateAboutDTO
    {
        [Required(ErrorMessage = "Section title cannot be null")]
        [StringLength(200, ErrorMessage = "Section title cannot be longer than 200 characters")]
        public string AboutTitle { get; set; }

        [Required(ErrorMessage = "Section description cannot be null")]
        [StringLength(1000, ErrorMessage = "Section description cannot be longer than 1000 characters")]
        public string AboutDescription { get; set; }

        [Required(ErrorMessage = "Image cannot be null")]
        public IFormFile Image { get; set; }
    }

}
