using System.ComponentModel.DataAnnotations;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.DTOs.MemberDTOs
{
    public class AddMemberDTO
    {
        [Required, MaxLength(150)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Phone, MaxLength(20)]
        public string? PhoneNumber { get; set; }
    }
}
