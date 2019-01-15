namespace MyLibrary.Web.Models
{
    using System;
    using MyLibrary.Models;

    public class IndexBooksViewModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public string Author { get; set; }
    }
}