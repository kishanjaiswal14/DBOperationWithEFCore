using DBOperationWithEFCore.DTOs;
using DBOperationWithEFCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBOperationWithEFCore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookPriceController : ControllerBase
    {
        private readonly IBookPriceService _bookPriceService;

        public BookPriceController(IBookPriceService bookPriceService)
        {
            this._bookPriceService = bookPriceService;
        }

        [HttpGet("{title}")]
        public async Task<ActionResult<List<BookPriceWithCurrencyDto>>> GetAllPriceWithCurrencyTitle(string title)
        {
            var bookprices = await _bookPriceService.GetINRCurrencyBookAsync(title);
            return bookprices;
        }
    }
}
