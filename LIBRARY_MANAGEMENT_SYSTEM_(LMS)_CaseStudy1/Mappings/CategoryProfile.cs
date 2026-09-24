using AutoMapper;
using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.DTOs.CategoryDTOs;
using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Models;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<AddCategoryDTO, Category>();

            CreateMap<Category, CategoryDTO>();
        }
    }
}
