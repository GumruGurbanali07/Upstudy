using System.ComponentModel.DataAnnotations;

namespace CourseApp.Models
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }
        public string AboutTitle { get; set; }
        public string AboutDescription { get; set; }
        public string Image { get; set; }
    }
}
