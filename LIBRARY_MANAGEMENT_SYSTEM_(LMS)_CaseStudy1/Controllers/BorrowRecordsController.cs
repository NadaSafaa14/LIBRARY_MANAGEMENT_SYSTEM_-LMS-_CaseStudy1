using AutoMapper;
using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Data;
using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.DTOs.BorrowRecordDTOs;
using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Mappings;
using LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LIBRARY_MANAGEMENT_SYSTEM__LMS__CaseStudy1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowRecordsController : ControllerBase
    {
        protected readonly AppDbContext _context;

        protected readonly IMapper _mapper;

        public BorrowRecordsController()
        {
            _context = new AppDbContext();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BorrowRecordProfile());
            });

            _mapper = config.CreateMapper();
        }

        [HttpPost]
        public IActionResult AddBorrowRecord([FromBody] AddBorrowRecordDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_context.Members.Any(m => m.Id == dto.MemberId))
            {
                return NotFound($"Member with ID {dto.MemberId} does not exist");
            }

            if (!_context.Books.Any(b => b.Id == dto.BookId))
            {
                return NotFound($"Book with ID {dto.BookId} does not exist");
            }

            if (!_context.Books.Any(b => b.Id == dto.BookId && b.AvailableCopies > 0))
            {
                return BadRequest($"No available copies for book with ID {dto.BookId}");
            }

            _context.Books.First(b => b.Id == dto.BookId).AvailableCopies--;

            var borrowrecord = _mapper.Map<BorrowRecord>(dto); 

            _context.BorrowRecords.Add(borrowrecord);

            _context.SaveChanges();

            return Created();
        }

        [HttpPut("return/{id}")]
        public IActionResult ReturnBorrowRecord([FromRoute] int id )
        {
            var borrowRecord = _context.BorrowRecords.FirstOrDefault(br => br.Id == id);

            if (borrowRecord == null)
            {
                return NotFound($"Borrow record with ID {id} does not exist");
            }

            if (borrowRecord.ReturnDate != null)
            {
                return BadRequest($"Borrow record with ID {id} has already been returned");
            }

            borrowRecord.ReturnDate = DateTime.Now;

            var book = _context.Books.First(b => b.Id == borrowRecord.BookId);

            book.AvailableCopies++;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBorrowRecord(int id)
        {
            var br = _context.BorrowRecords.FirstOrDefault(b => b.Id == id);

            if(br == null)
            {
                return NotFound();
            }

            if(br.ReturnDate == null)
            {
                return BadRequest($"Borrow record with ID {id} has not been returned");
            }

            _context.BorrowRecords.Remove(br);

            _context.SaveChanges();

            return NoContent();

        }
    }
}
