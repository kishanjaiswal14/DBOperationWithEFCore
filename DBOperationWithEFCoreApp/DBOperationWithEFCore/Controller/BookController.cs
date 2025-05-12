using DBOperationWithEFCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBOperationWithEFCore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(IBookService bookService) : ControllerBase
    {
        private readonly IBookService _bookService = bookService;

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBookAsync([FromRoute] int bookId)
        {
            var isDeleted = await _bookService.DeleteBookAsync(bookId);

            if(isDeleted == false)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("{language}")]
        public async Task<IActionResult> FilterBookByLanguage(string language)
        {
            var books = await _bookService.FilterBooksByLanguageAsync(language);
            return Ok(books);
        }

        [HttpGet]
        public async Task<IActionResult> FilterBookByRange(
            [FromQuery] int minRange, [FromQuery] int maxRange)
        {
            var books = await _bookService.FilterBooksByPriceAsync(minRange, maxRange);
            return Ok(books);
        }
    }
}
