namespace MyLibrary.Web.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SearchModel : PageModel
    {
        private readonly MyLibraryContext context;

        public SearchModel(MyLibraryContext context)
        {
            this.context = context;
            this.SearchResult = new List<SearchViewModel>();
        }

        public List<SearchViewModel> SearchResult { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public async Task OnGet()
        {
            if (string.IsNullOrEmpty(this.SearchTerm))
            {
                return;
            }

            var foundAuthors = await this.context
                .Authors
                .Where(a => a.Name.ToLower().Contains(this.SearchTerm.ToLower()))
                .OrderBy(a => a.Name)
                .Select(a => new SearchViewModel
                {
                    Id = a.Id,
                    SearchResult = a.Name,
                    Type = "Author"
                })
                .ToListAsync();

            var foundBooks = await this.context
                .Books
                .Where(b => b.Title.ToLower().Contains(this.SearchTerm.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => new SearchViewModel
                {
                    Id = b.Id,
                    SearchResult = b.Title,
                    Type = "Book"
                })
                .ToListAsync();

            this.SearchResult.AddRange(foundAuthors);
            this.SearchResult.AddRange(foundBooks);

            foreach (var result in this.SearchResult)
            {
                var markedResult = Regex
                    .Replace(result.SearchResult, $"({Regex.Escape(this.SearchTerm)}",
                        match => $"<strong class=\"text-danger\">{match.Groups[0].Value}</strong>",
                        RegexOptions.IgnoreCase | RegexOptions.Compiled);

                result.SearchResult = markedResult;
            }
        }
    }
}