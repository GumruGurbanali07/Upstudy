using System.ComponentModel.DataAnnotations;

namespace CourseApp.Areas.Admin.Models.AdminDTOs
{
    public class UpdateAccountDTO
    {
        [Required(ErrorMessage = "Name cannot be null")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname cannot be null")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Username cannot be null")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email cannot be null")]
        public string Email { get; set; }

       
        public IFormFile? Image { get; set; }

       public string ImagePreview { get; set; }
    }
}
