namespace BookManagementSystem.DataAccessLayer
{
    using BookManagementSystem.Entities;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("BooksDB");
        }
    }

}
