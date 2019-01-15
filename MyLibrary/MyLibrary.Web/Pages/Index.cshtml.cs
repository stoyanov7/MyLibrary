namespace MyLibrary.Web.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class IndexModel : PageModel
    {
        private readonly MyLibraryContext context;

        public IndexModel(MyLibraryContext context)
        {
            this.context = context;
        }

        public IEnumerable<IndexBooksViewModel> Books { get; set; }

        public async Task OnGet()
        {
            this.Books = await this.context
                .Books
                .Include(b => b.Author)
                .OrderBy(b => b.Title)
                .Select(b => new IndexBooksViewModel
                {
                    BookId = b.Id,
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                    Author = b.Author.Name
                })
                .ToListAsync();
        }
    }
}
