namespace CourseApp.Models
{
    public class CourseSubcribe
    {
        public int CourseSubcribeId { get; set; }
        public int  StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Courses Course { get; set; }
    }
}
