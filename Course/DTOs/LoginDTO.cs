using System.ComponentModel.DataAnnotations;

namespace CourseApp.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="Section can not be null")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Section can not be null")]
        public string Password { get; set; }
    }
}
