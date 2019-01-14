﻿namespace MyLibrary.Models
{
    using System;

    public class MovieBorrowers
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int BorrowerId { get; set; }
        public Borrower Borrower { get; set; }

        public DateTime BorrowDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public bool IsMovieReturned { get; set; }
    }
}