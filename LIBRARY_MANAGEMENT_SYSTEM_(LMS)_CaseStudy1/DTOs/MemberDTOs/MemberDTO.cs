using System.ComponentModel.DataAnnotations;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.DTOs.MemberDTOs
{
    public class MemberDTO
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Phone, MaxLength(20)]
        public string? PhoneNumber { get; set; }
    }
}
