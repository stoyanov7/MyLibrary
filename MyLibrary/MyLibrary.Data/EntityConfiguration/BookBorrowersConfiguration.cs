namespace MyLibrary.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class BookBorrowersConfiguration : IEntityTypeConfiguration<BookBorrowers>
    {
        public void Configure(EntityTypeBuilder<BookBorrowers> builder)
        {
            builder
                .HasKey(e => new { e.BookId, e.BorrowerId });

            builder
                .HasOne(e => e.Book)
                .WithMany(b => b.Borrowerses)
                .HasForeignKey(b => b.BookId);

            builder
                .HasOne(e => e.Borrower)
                .WithMany(b => b.BorrowersedBooks)
                .HasForeignKey(b => b.BorrowerId);
        }
    }
}