using AutoMapper;
using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Data;
using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Mappings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        protected readonly AppDbContext _context;

        protected readonly IMapper _mapper;

        public MembersController()
        {
            _context = new AppDbContext();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MemberProfile());
            });

            _mapper = config.CreateMapper();
        }
    }
}
