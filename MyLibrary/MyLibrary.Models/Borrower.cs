namespace MyLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Borrower
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [MinLength(3)]
        public string Address { get; set; }

        public ICollection<BookBorrowers> BorrowersedBooks { get; set; } = new List<BookBorrowers>();

        public ICollection<MovieBorrowers> BorrowersedMovies { get; set; } = new List<MovieBorrowers>();
    }
}