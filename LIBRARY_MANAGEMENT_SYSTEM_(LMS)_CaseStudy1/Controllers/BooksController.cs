using AutoMapper;
using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Data;
using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.DTOs.BookDTOs;
using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Mappings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        protected readonly AppDbContext _context;

        protected readonly IMapper _mapper;
        
        public BooksController()
        {
            _context = new AppDbContext();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BookProfile());
            });

            _mapper = config.CreateMapper();
        }

        [HttpGet("price-greater-than/{price}")]
        public IActionResult GetBooksByPriceGreaterThan(decimal price)
        {
            var books = _context.Books.Where(b => b.Price > price).ToList();

            if (books == null || books.Count == 0)
            {
                return NotFound($"No books found with price greater than {price}");
            }

            var dto = _mapper.Map<List<BookDTO>>(books);

            return Ok(dto);
        }

        [HttpGet("price-between")]
        public IActionResult GetBooksByPriceBetween([FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
        {
            var books = _context.Books.Where(b => b.Price >= minPrice && b.Price <= maxPrice).ToList();

            if (books == null || books.Count == 0)
            {
                return NotFound($"No books found with price between {minPrice} and {maxPrice}");
            }

            var dto = _mapper.Map<List<BookDTO>>(books);

            return Ok(dto);
        }

        [HttpGet("search-title")]
        public IActionResult SearchBooksByTitle([FromQuery] string title)
        {
            var books = _context.Books.Where(b => b.Title.Contains(title)).ToList();

            if (books == null || books.Count == 0)
            {
                return NotFound($"No books found with title containing {title}");
            }

            var dto = _mapper.Map<List<BookDTO>>(books);

            return Ok(dto);
        }

        [HttpGet("first")]
        public IActionResult GetFirstBook()
        {
            var book = _context.Books.FirstOrDefault();

            if (book == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<BookDTO>(book);

            return Ok(dto);
        }

        [HttpGet("first-available")]
        public IActionResult GetFirstAvailableBook()
        {
            var book = _context.Books.FirstOrDefault(b => b.AvailableCopies > 0);

            if (book == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<BookDTO>(book);

            return Ok(dto);
        }

        [HttpGet("book/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<BookDTO>(book);

            return Ok(dto);
        }

        [HttpGet("last")]
        public IActionResult GetLastBook()
        {
            //var book = _context.Books.LastOrDefault();

            var book = _context.Books.OrderBy(b => b.Id).LastOrDefault();

            var dto = _mapper.Map<BookDTO>(book);

            return Ok(dto);
        }


        [HttpGet("exists/{id}")]
        public IActionResult CheckBookExists(int id)
        {
            var exists = _context.Books.Any(b => b.Id == id);

            return Ok(exists);
        }

        [HttpGet("verify-all-available")]
        public IActionResult VerifyAllBooksAvailable()
        {
            var allAvailable = _context.Books.All(b => b.AvailableCopies > 0);

            return Ok(allAvailable);
        }

        [HttpGet("titles")]
        public IActionResult GetAllBookTitles()
        {
            var titles = _context.Books.Select(b => b.Title).ToList();

            return Ok(titles);
        }

        [HttpGet("sort-title")]
        public IActionResult GetBooksSortedByTitle()
        {
            var books = _context.Books.OrderBy(b => b.Title).ToList();

            var dto = _mapper.Map<List<BookDTO>>(books);

            return Ok(dto);
        }

        [HttpGet("lowest-price")]
        public IActionResult GetBookWithLowestPrice()
        {
            var book = _context.Books.Min(b => b.Price);

            //var dto = _mapper.Map<BookDTO>(book);

            return Ok(book);
        }

        [HttpGet("paged")]
        public IActionResult GetBooksPaged([FromQuery] int PageNumber, [FromQuery] int PageSize)
        {
            var books = _context.Books.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();

            var dto = _mapper.Map<List<BookDTO>>(books);

            return Ok(dto);
        }


    }
}
