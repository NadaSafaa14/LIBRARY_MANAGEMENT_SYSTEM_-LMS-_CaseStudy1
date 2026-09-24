using AutoMapper;
using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.DTOs.BookDTOs;
using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Models;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Mappings
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<AddBookDTO, Book>();

            CreateMap<Book, BookDTO>();
        }
    }
}
