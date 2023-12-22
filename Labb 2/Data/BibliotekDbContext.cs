using Labb_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_2.Data;

public class BibliotekDbContext : DbContext
{
    public BibliotekDbContext(DbContextOptions<BibliotekDbContext> options)
        : base(options)
    {

    }

    public DbSet<Book> Books { get; set; }
}
