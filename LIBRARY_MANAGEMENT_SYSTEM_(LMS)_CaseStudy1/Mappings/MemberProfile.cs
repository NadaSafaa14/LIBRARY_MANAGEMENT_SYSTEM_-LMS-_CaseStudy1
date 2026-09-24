using AutoMapper;
using AutoMapper.Execution;
using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.DTOs.MemberDTOs;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Mappings
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<AddMemberDTO, Member>();

            CreateMap<Member, MemberDTO>();
        }
    }
}
