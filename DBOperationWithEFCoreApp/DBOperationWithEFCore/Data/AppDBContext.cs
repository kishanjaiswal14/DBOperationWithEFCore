using Microsoft.EntityFrameworkCore;

namespace DBOperationWithEFCore.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "C# Fundamentals",
                    Description = "Learn C# from basics",
                    LanguageId = 1,
                    NoOfPages = 300,
                    IsActive = true,
                    CreatedOn = new DateTime(2024, 01, 01)
                },
                new Book
                {
                    Id = 2,
                    Title = "ASP.NET Core",
                    Description = "Web development with ASP.NET Core",
                    LanguageId = 2,
                    NoOfPages = 400,
                    IsActive = true,
                    CreatedOn = new DateTime(2024, 01, 01)
                },
                new Book
                {
                    Id = 3,
                    Title = "Entity Framework Core",
                    Description = "Master EF Core",
                    LanguageId = 3,
                    NoOfPages = 350,
                    IsActive = true,
                    CreatedOn = new DateTime(2024, 01, 01)
                },
                new Book
                {
                    Id = 4,
                    Title = "LINQ in Depth",
                    Description = "Deep dive into LINQ",
                    LanguageId = 4,
                    NoOfPages = 280,
                    IsActive = true,
                    CreatedOn = new DateTime(2024, 01, 01)
                }
            );


            modelBuilder.Entity<Currency>().HasData(
                new Currency() { Id = 1, Title = "INR", Description = "Indian INR" },
                new Currency() { Id = 2, Title = "Dollar", Description = "US Dollar" },
                new Currency() { Id = 3, Title = "Euro", Description = "Euro" },
                new Currency() { Id = 4, Title = "Dinar", Description = "Dinar" }
            );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = 1, Title = "Hindi", Description = "Hindi" },
                new Language() { Id = 2, Title = "Tamil", Description = "Tamil" },
                new Language() { Id = 3, Title = "Punjab", Description = "Punjab" },
                new Language() { Id = 4, Title = "Urdu", Description = "Urdu" }
                );



            modelBuilder.Entity<BookPrice>().HasData(
                new BookPrice { Id = 1, Amount = 500, BookId = 1, CurrencyId = 1 }, 
                new BookPrice { Id = 2, Amount = 600, BookId = 2, CurrencyId = 2 }, 
                new BookPrice { Id = 3, Amount = 700, BookId = 3, CurrencyId = 1 }, 
                new BookPrice { Id = 4, Amount = 800, BookId = 4, CurrencyId = 3 }, 
                new BookPrice { Id = 5, Amount = 900, BookId = 1, CurrencyId = 4 }  
                );

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
        public DbSet<Currency> Currencies { get; set; }

    }
}
