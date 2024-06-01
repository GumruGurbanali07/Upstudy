using System.ComponentModel.DataAnnotations;

namespace CourseApp.Models
{
	public class Graduate
	{
		[Key]
		public int GraduateId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
        public string Image { get; set; }
        public string Comment { get; set; }
        public string CurrentWork { get; set; }
        public bool IsActive { get; set; }
    }
}
