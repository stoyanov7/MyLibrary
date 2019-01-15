namespace MyLibrary.Web.Pages.Books
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class AddModel : PageModel
    {
        private readonly MyLibraryContext context;

        public AddModel(MyLibraryContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        public string Author { get; set; }

        [BindProperty]
        [Display(Name = "Image URL")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (this.ModelState.IsValid)
            {
                var book = new Book { Title = this.Title };

                var author = await this.context
                    .Authors
                    .FirstOrDefaultAsync(a => a.Name == this.Author);

                if (author is null)
                {
                    author = new Author { Name = this.Author };
                    this.context.Authors.Add(author);
                    await this.context.SaveChangesAsync();
                }

                book.AuthorId = author.Id;
                book.ImageUrl = this.ImageUrl;
                book.Description = this.Description;

                this.context.Books.Add(book);
                await this.context.SaveChangesAsync();

                return this.RedirectToPage("/Books/Details", new { id = book.Id});
            }

            return this.Page();
        }
    }
}