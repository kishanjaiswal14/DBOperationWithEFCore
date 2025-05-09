using DBOperationWithEFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace DBOperationWithEFCore.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly AppDBContext _appDBContext;

        public CurrencyService(AppDBContext appDBContext)
        {
            this._appDBContext = appDBContext;
        }
        public async Task<List<Currency>> GetCurrencyListAsync()
        {
            //var currencies = await _appDBContext.Currencies.ToListAsync();
            var result = await (from currencies in _appDBContext.Currencies select currencies).ToListAsync();
            //var currencies = _appDBContext.Set<Currency>().ToListAsync();
            return result;
        }

        public async Task<Currency> GetCurrencyByIdAsync(int id)
        {
            //this find in primary key
            //var res = await _appDBContext.Currencies.FindAsync(id);

            var res = await _appDBContext.Currencies.FirstOrDefaultAsync(c => c.Id == id);
            return res;
        }

        public async Task<Currency> GetCurrencyByNameAsync(string name)
        {
            var res = await _appDBContext.Currencies.Where(c => c.Title == name).FirstOrDefaultAsync();
            return res;
        }
    }
}
