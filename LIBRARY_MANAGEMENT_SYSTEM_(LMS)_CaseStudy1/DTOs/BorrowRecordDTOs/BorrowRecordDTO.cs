using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Models;
using System.ComponentModel.DataAnnotations;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.DTOs.BorrowRecordDTOs
{
    public class BorrowRecordDTO
    {
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }
        public string BookTitle { get; set; }

        [Required]
        public int MemberId { get; set; }
        public string MemberName { get; set; }

        [Required]
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
