using System.ComponentModel.DataAnnotations;

namespace CourseApp.Models
{
    public class BlogCategory
    {
        [Key]
        public int BlogCategoryId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

    }
}
