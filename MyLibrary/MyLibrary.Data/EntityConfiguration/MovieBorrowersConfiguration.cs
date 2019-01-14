namespace MyLibrary.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class MovieBorrowersConfiguration : IEntityTypeConfiguration<MovieBorrowers>
    {
        public void Configure(EntityTypeBuilder<MovieBorrowers> builder)
        {
            builder
                .HasOne(e => e.Movie)
                .WithMany(b => b.Borrowerses)
                .HasForeignKey(b => b.MovieId);

            builder
                .HasOne(e => e.Borrower)
                .WithMany(b => b.BorrowersedMovies)
                .HasForeignKey(b => b.BorrowerId);

            builder
                 .HasKey(e => new { e.MovieId, e.BorrowerId, e.BorrowDate });
        }
    }
}