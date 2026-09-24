using System.ComponentModel.DataAnnotations;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required , MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
