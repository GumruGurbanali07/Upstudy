using System.ComponentModel.DataAnnotations;

namespace CourseApp.Areas.Admin.Models.AdminDTOs
{
    public class AdminLoginDTO
    {
        [Required(ErrorMessage = "Username cannot be null")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 50 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be null")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 100 characters")]
        public string Password { get; set; }
    }
}
