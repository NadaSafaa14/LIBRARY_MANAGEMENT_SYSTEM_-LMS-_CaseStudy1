using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Models;
using System.ComponentModel.DataAnnotations;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.DTOs.BookDTOs
{
    public class AddBookDTO
    {
        [Required, MaxLength(200)]
        public string Title { get; set; }

        [Required, MaxLength(100)]
        public string Author { get; set; }

        [Required, Range(1900, 2027)]
        public int PublishedYear { get; set; }

        [Required, Range(1, int.MaxValue)]
        public decimal Price { get; set; }

        [Required, Range(0, int.MaxValue)]
        public int AvailableCopies { get; set; }

        public int CategoryId { get; set; }
    }
}
