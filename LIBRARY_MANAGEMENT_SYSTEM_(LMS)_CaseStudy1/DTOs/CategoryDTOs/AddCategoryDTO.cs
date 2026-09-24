using System.ComponentModel.DataAnnotations;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.DTOs.CategoryDTOs
{
    public class AddCategoryDTO
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}
