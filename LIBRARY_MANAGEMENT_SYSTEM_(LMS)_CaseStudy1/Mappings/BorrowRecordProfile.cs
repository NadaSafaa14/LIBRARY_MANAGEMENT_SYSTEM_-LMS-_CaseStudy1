using AutoMapper;
using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.DTOs.BorrowRecordDTOs;
using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Models;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Mappings
{
    public class BorrowRecordProfile : Profile
    {
        public BorrowRecordProfile()
        {
            CreateMap<AddBorrowRecordDTO, BorrowRecord>();

            CreateMap<BorrowRecord, BorrowRecordDTO>()
                .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title))
                .ForMember(dest => dest.MemberName, opt => opt.MapFrom(src => src.Member.FullName));
        }
    }
}
