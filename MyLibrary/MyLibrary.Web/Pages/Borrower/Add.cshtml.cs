namespace MyLibrary.Web.Pages.Borrower
{
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Models;
    using MyLibrary.Models;

    public class AddModel : PageModel
    {
        private readonly MyLibraryContext context;

        public AddModel(MyLibraryContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public AddBorrowerBingingModel AddBorrowerBingingModel { get; set; }

        public IActionResult OnPost()
        {
            if (this.ModelState.IsValid)
            {
                var borrower = new Borrower
                {
                    Name = this.AddBorrowerBingingModel.Name,
                    Address = this.AddBorrowerBingingModel.Address
                };

                this.context.Borrowers.Add(borrower);
                this.context.SaveChanges();

                return this.RedirectToPage("/Index");
            }

            return this.Page();
        }
    }
}