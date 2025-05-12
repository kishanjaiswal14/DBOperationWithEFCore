using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DBOperationWithEFCore.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "John" },
                new Customer { CustomerId = 2, Name = "Alice" },
                new Customer { CustomerId = 3, Name = "Bob" }, 
                new Customer { CustomerId = 4, Name = "Mark" }   
            );


            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, Amount = 1000, CustomerId = 1 },
                new Order { OrderId = 2, Amount = 600, CustomerId = 2 },
                new Order { OrderId = 3, Amount = 200, CustomerId = 1 },
                new Order { OrderId = 4, Amount = 300, CustomerId = 2 }
            );

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasData(new Author
                {
                    Id = 1,
                    Name = "John"
                });

                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name).IsRequired();
            });

            modelBuilder.Entity<Book>().HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "C# Fundamentals",
                    Description = "Learn C# from basic",
                    LanguageId = 1,
                    NoOfPages = 300,
                    IsActive = true,
                    CreatedOn = new DateTime(2024, 01, 01),
                    AuthorId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "ASP.NET Core",
                    Description = "Web development with ASP.NET  Core",
                    LanguageId = 2,
                    NoOfPages = 400,
                    IsActive = true,
                    CreatedOn = new DateTime(2024, 01, 01),
                    AuthorId = 1

                },
                new Book
                {
                    Id = 3,
                    Title = "Entity Framework Core",
                    Description = "Master EFCore",
                    LanguageId = 3,
                    NoOfPages = 350,
                    IsActive = true,
                    CreatedOn = new DateTime(2024, 01, 01),
                    AuthorId = 1

                },
                new Book
                {
                    Id = 4,
                    Title = "LINQ in Depth",
                    Description = "Deep dive into  LINQ",
                    LanguageId = 4,
                    NoOfPages = 280,
                    IsActive = true,
                    CreatedOn = new DateTime(2024, 01, 01),
                    AuthorId = 1

                }
            );


            modelBuilder.Entity<Currency>().HasData(
                new Currency() { Id = 1, Title = "INR", Description = "INR" },
                new Currency() { Id = 2, Title = "Dollar", Description = "US " },
                new Currency() { Id = 3, Title = "Euro", Description = "Euros" },
                new Currency() { Id = 4, Title = "Dinar", Description = "Dinars" }
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

            //modelBuilder.Entity<BookPublisher>(entity =>
            //{
            //    entity.HasKey(bp => new { bp.BookId, bp.PublisherId });

            //    entity.HasOne(bp => bp.Book)
            //    .WithMany(b => b.BookPublisher)
            //    .HasForeignKey(bp => bp.BookId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //    entity.HasOne(bp => bp.publisher)
            //    .WithMany(p => p.BookPublisher)
            //    .HasForeignKey(bp => bp.PublisherId)
            //    .OnDelete(DeleteBehavior.NoAction);
            //});

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
