namespace MyLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        public string Description { get; set; }

        [Required]
        public int DirectorId { get; set; }
        public Director Director { get; set; }

        [DataType(DataType.ImageUrl)]
        public string PosterImageUrl { get; set; }

        public bool IsBorrowed { get; set; }

        public ICollection<MovieBorrowers> Borrowerses { get; set; } = new List<MovieBorrowers>();
    }
}