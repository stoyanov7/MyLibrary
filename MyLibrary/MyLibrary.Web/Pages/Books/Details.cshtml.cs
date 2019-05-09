namespace MyLibrary.Web.Pages.Books
{
    using System.Threading.Tasks;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    public class DetailsModel : PageModel
    {
        private readonly MyLibraryContext context;

        public DetailsModel(MyLibraryContext context)
        {
            this.context = context;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            var book = await this.context
                .Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return this.NotFound();
            }

            this.Id = book.Id;
            this.Title = book.Title;
            this.Description = book.Description;
            this.ImageUrl = book.ImageUrl;
            this.Author = book.Author.Name;

            return this.Page();
        }
    }
}