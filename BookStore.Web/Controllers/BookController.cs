using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly Iunitofwork _unitofwork;
        public BookController(Iunitofwork unitofwork)
        {
            _unitofwork= unitofwork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _unitofwork.Books.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _unitofwork.Books.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            await _unitofwork.Books.AddAsync(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.id }, book);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            if (book == null || book.id != id)
            {
                return BadRequest();
            }
            var existingBook = await _unitofwork.Books.GetByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            await _unitofwork.Books.UpdateAsync(book);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var existingBook = await _unitofwork.Books.GetByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            await _unitofwork.Books.DeleteAsync(id);
            return NoContent();
        }
    }
}
