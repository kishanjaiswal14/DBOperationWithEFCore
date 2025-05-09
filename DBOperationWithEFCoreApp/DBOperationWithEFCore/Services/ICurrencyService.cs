using DBOperationWithEFCore.Data;

namespace DBOperationWithEFCore.Services
{
    public interface ICurrencyService
    {
        Task<List<Currency>> GetCurrencyListAsync();
        Task<Currency> GetCurrencyByIdAsync(int id);
        Task<Currency> GetCurrencyByNameAsync(string name);
    }
}
