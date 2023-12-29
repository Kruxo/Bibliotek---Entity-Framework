using Labb_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_2.Data;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Borrower> Borrowers { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<BookBorrower> BookBorrowers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>()
            .HasKey(ba => new { ba.BookId, ba.AuthorId });

        modelBuilder.Entity<BookAuthor>()
            .HasOne(ba => ba.Book)
            .WithMany(b => b.Authors)
            .HasForeignKey(ba => ba.BookId);

        modelBuilder.Entity<BookAuthor>()
            .HasOne(ba => ba.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(ba => ba.AuthorId);

        modelBuilder.Entity<BookBorrower>()
            .HasKey(bb => new { bb.BookId, bb.BorrowerId });

        modelBuilder.Entity<BookBorrower>()
            .HasOne(bb => bb.Book)
            .WithMany(b => b.Borrowers)
            .HasForeignKey(bb => bb.BookId);

        modelBuilder.Entity<BookBorrower>()
            .HasOne(bb => bb.Borrower)
            .WithMany(b => b.BorrowedBooks)
            .HasForeignKey(bb => bb.BorrowerId);
    }

}
