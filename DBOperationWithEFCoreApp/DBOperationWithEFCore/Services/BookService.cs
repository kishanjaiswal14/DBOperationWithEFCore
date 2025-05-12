using DBOperationWithEFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace DBOperationWithEFCore.Services
{
    public class BookService : IBookService
    {
        private readonly AppDBContext _appDBContext;

        public BookService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<List<Book>> AddBooksAsync(List<Book> models)
        {
            await _appDBContext.Books.AddRangeAsync(models);
            await _appDBContext.SaveChangesAsync();
            return models;

        }

        public async Task<Book> AddBookWithAuthorAsync(Book model)
        {
            await _appDBContext.Books.AddAsync(model);
            await _appDBContext.SaveChangesAsync();
            return model;
        }

        public async Task<bool> DeleteBookAsync(int bookId)
        {
            var book = await _appDBContext.Books.FirstOrDefaultAsync(x => x.Id == bookId);

            //var book2 = await _appDBContext.Books.Where(x => x.Id == 4).ExecuteDeleteAsync();

            //var booklist = await _appDBContext.Books.Where(x => x.Id < 3).ToListAsync();

            //_appDBContext.Books.RemoveRange(booklist);
            //await _appDBContext.SaveChangesAsync();

            if(book != null)
            {
                _appDBContext.Remove(bookId);
                await _appDBContext.SaveChangesAsync();
                return true;

            }

            return false;
        }

        public async Task<List<Book>> FilterBooksByLanguageAsync(string language)
        {
            var books = await (from book in _appDBContext.Books join lan in _appDBContext.Languages
                               on book.LanguageId equals lan.Id where lan.Title == language orderby book.Id select book).ToListAsync();

            return books;
        }

        public async Task<List<Book>> FilterBooksByPriceAsync(int minRange, int maxRange)
        {
            var books = await (from book in _appDBContext.Books join bookPrice in _appDBContext.BookPrices
                               on book.Id equals bookPrice.BookId where bookPrice.Amount >= minRange &&
                               bookPrice.Amount <= maxRange select book).ToListAsync();

            return books;
        }

        public async Task<Book> UpdateBookAsync(Book model)
        {
            var book = await _appDBContext.Books.FindAsync(model.Id);

            if (book != null)
            {
                book.Description = model.Description;
                book.NoOfPages = model.NoOfPages;
                book.Language = model.Language;
                book.LanguageId = model.LanguageId;
            }

            await _appDBContext.SaveChangesAsync();

            return book;
        }
    }
}
