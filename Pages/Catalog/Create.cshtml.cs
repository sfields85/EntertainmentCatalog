using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EntertainmentCatalog.Models;

namespace EntertainmentCatalog.Pages.Catalog
{
    public class CreateModel : PageModel
    {
        private readonly EntertainmentCatalog.Models.EntertainmentCatalogContext _context;

        public CreateModel(EntertainmentCatalog.Models.EntertainmentCatalogContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public log Catalog { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.log.Add(Catalog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}