using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        { 
        
        }
        public DbSet<Book> Books { get; set; }
    }
}
