using Microsoft.EntityFrameworkCore;

namespace BookService.Models
{
    public class BookDatabaseContext : DbContext
    {
        public BookDatabaseContext(DbContextOptions<BookDatabaseContext> options)
            : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookInventory> Inventory { get; set; }
    }
}
