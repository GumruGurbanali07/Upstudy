using System.ComponentModel.DataAnnotations;

namespace CourseApp.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage ="Section can not be null")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Section can not be null")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Section can not be null")]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "Section can not be null")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Section can not be null")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Section can not be null")]
        public string Password { get; set; }
    }
}
