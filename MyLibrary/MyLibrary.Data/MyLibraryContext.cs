namespace MyLibrary.Data
{
    using EntityConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class MyLibraryContext : DbContext
    {
        public MyLibraryContext()
        {
        }

        public MyLibraryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Borrower> Borrowers { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<BookBorrowers> BookBorrowerses { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<MovieBorrowers> MovieBorrowerses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookBorrowersConfiguration());
            modelBuilder.ApplyConfiguration(new MovieBorrowersConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
