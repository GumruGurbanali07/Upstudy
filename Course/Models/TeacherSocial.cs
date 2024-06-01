namespace CourseApp.Models
{
    public class TeacherSocial
    {
        public int TeacherSocialId { get; set; }
        public string Icon { get; set; }
        public string SocialTitle { get; set; }
        public string ScoialLink { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
