

namespace BookStore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly Iunitofwork _unitofwork;
        public AuthorController(Iunitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }


        [HttpGet]

        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _unitofwork.Authors.GetAllAsync();
            return Ok(authors);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _unitofwork.Authors.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] Author author)
        {
            if (author == null)
            {
                return BadRequest();
            }
            await _unitofwork.Authors.AddAsync(author);
            return CreatedAtAction(nameof(GetAuthorById), new { id = author.id }, author);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] Author author)
        {
            if (author == null || author.id != id)
            {
                return BadRequest();
            }
            var existingAuthor = await _unitofwork.Authors.GetByIdAsync(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }
            await _unitofwork.Authors.UpdateAsync(author);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _unitofwork.Authors.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            await _unitofwork.Authors.DeleteAsync(id);
            return NoContent();
        }

    }
}
