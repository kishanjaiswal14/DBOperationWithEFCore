using DBOperationWithEFCore.Data;

namespace DBOperationWithEFCore.Services
{
    public interface IBookService
    {
        Task<List<Book>> AddBooksAsync(List<Book> models);
        Task<Book> UpdateBookAsync(Book model);
        Task<bool> DeleteBookAsync(int bookId);
        Task<Book> AddBookWithAuthorAsync(Book model);
        Task<List<Book>> FilterBooksByPriceAsync(int minRange, int maxRange);
        Task<List<Book>> FilterBooksByLanguageAsync(string language);
    }
}
