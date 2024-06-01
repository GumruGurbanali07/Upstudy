using System.ComponentModel.DataAnnotations;

namespace CourseApp.Areas.Admin.Models.AdminDTOs
{
    public class CreateAdminDTO
    {
        [Required(ErrorMessage = "Name cannot be null")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname cannot be null")]
        [StringLength(50, ErrorMessage = "Surname cannot be longer than 50 characters")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Username cannot be null")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 50 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email cannot be null")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Image cannot be null")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Password cannot be null")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 100 characters")]
        public string Password { get; set; }
    }
}
