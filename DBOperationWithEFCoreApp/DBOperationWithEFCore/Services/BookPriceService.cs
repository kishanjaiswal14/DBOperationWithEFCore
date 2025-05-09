using DBOperationWithEFCore.Data;
using DBOperationWithEFCore.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DBOperationWithEFCore.Services
{
    public class BookPriceService : IBookPriceService
    {
        private readonly AppDBContext _appDBContext;

        public BookPriceService(AppDBContext appDBContext)
        {
            this._appDBContext = appDBContext;
        }

        public async Task<List<BookPriceWithCurrencyDto>> GetINRCurrencyBookAsync(string title)
        {
            var pricesInINR = await (from bookprice in _appDBContext.BookPrices
                                     join currency in _appDBContext.Currencies on bookprice.CurrencyId equals currency.Id
                                     where currency.Title == title
                                     select new BookPriceWithCurrencyDto()
                                     {
                                         Price = bookprice.Amount,
                                         Currency = currency.Title
                                     }).ToListAsync(); 

            return pricesInINR;
        }
    }
}
