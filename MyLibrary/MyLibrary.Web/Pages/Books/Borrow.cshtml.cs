namespace MyLibrary.Web.Pages.Books
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using MyLibrary.Models;

    public class BorrowModel : PageModel
    {
        private readonly MyLibraryContext context;

        public BorrowModel(MyLibraryContext context)
        {
            this.context = context;
            this.StartDate = DateTime.UtcNow;
            this.Borrowers = new List<SelectListItem>();
        }

        [BindProperty]
        [Required]
        [Display(Name = "Borrower")]
        public int BorrowerId { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public IEnumerable<SelectListItem> Borrowers { get; set; }

        public void OnGet()
        {
            this.Borrowers = this.context
                .Borrowers
                .Select(b => new SelectListItem
                {
                    Text = b.Name,
                    Value = b.Id.ToString()
                })
                .ToList();
        }

        public void OnPost()
        {
            if (!this.ModelState.IsValid)
            {
                // TODO: Show error page
                return;
            }

            // TODO: If the book has been borrowed for the current period, return an error page

            var borrower = this.context
                .Borrowers
                .Find(this.BorrowerId);

            var bookId = Convert.ToInt32(this.RouteData.Values["id"]);
            var book = this.context.Books.Find(bookId);

            if (borrower == null || book == null)
            {
                // TODO: Add ModelError()
                return;
            }

            var bookBorrower = new BookBorrowers
            {
                BookId = book.Id,
                BorrowerId = borrower.Id,
                BorrowDate = this.StartDate,
                ReturnDate = this.EndDate
            };

            this.context.BookBorrowerses.Add(bookBorrower);
            this.context.SaveChanges();
        }
    }
}