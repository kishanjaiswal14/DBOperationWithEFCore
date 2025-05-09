using DBOperationWithEFCore.Data;
using DBOperationWithEFCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBOperationWithEFCore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            this._currencyService = currencyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCurrenciesAsync()
        {
            var currencies = await _currencyService.GetCurrencyListAsync();
            return Ok(currencies);
        }

        [HttpGet("GetCurrencyById/{id:int}")]
        public async Task<IActionResult> GetCurencyByIdAsync(int id)
        {
            var currency = await _currencyService.GetCurrencyByIdAsync(id);
            if (currency == null)
                return NotFound("This currency id is not valid : " + id);
            return Ok(currency);
        }
        
        [HttpGet("{name}")]
        public async Task<IActionResult> GetCurencyByNameAsync(string name)
        {
            var currency = await _currencyService.GetCurrencyByNameAsync(name);
            if (currency == null)
                return NotFound("This currency name is not valid : " + name);
            return Ok(currency);
        }
    }
}
