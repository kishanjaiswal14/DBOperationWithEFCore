using DBOperationWithEFCore.DTOs;

namespace DBOperationWithEFCore.Services
{
    public interface IBookPriceService
    {
        Task<List<BookPriceWithCurrencyDto>> GetINRCurrencyBookAsync(string title);
    }
}
