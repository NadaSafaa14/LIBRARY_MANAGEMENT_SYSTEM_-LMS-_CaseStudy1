using AutoMapper;
using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Data;
using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.DTOs.CategoryDTOs;
using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Mappings;
using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        protected readonly AppDbContext _context;

        protected readonly IMapper _mapper;

        public CategoriesController()
        {
            _context = new AppDbContext();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CategoryProfile());
            });

            _mapper = config.CreateMapper();
        }

        [HttpGet("book-count")]
        public IActionResult GetCategoryBookCounts()
        {
            var categoryBookCounts = _context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    BookCount = c.Books.Count()
                })
                .ToList();

            return Ok(categoryBookCounts);
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] AddCategoryDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_context.Categories.Any(c => c.Name == dto.Name))
            {
                return BadRequest($"Category with name {dto.Name} already exists");
            }

            var category = _mapper.Map<Category>(dto);

            _context.Categories.Add(category);

            _context.SaveChanges();

            return Created();
        }
    }
}
