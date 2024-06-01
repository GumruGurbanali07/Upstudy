using System.ComponentModel.DataAnnotations;

namespace CourseApp.Models
{
    public class ContactDetail
    {
        [Key]
        public int ContactDetailId { get; set; }
        public string  Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Iframe { get; set; }

    }
}
