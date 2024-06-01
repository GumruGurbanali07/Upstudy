using System.ComponentModel.DataAnnotations;

namespace CourseApp.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set;}
        public int BlogCategoryId { get; set; }
        public BlogCategory BlogCategory { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

    }
}
