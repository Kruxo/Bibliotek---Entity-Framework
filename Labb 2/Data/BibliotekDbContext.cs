using Labb_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_2.Data;

public class BibliotekDbContext : DbContext
{
    public BibliotekDbContext(DbContextOptions<BibliotekDbContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Borrower> Borrowers { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<BookBorrower> BookBorrowers { get; set; }
}
