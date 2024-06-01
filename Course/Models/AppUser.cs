using Microsoft.AspNetCore.Identity;

namespace CourseApp.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Image { get; set; }
    }
}
