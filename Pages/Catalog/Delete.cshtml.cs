using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntertainmentCatalog.Models;

namespace EntertainmentCatalog.Pages.Catalog
{
    public class DeleteModel : PageModel
    {
        private readonly EntertainmentCatalog.Models.EntertainmentCatalogContext _context;

        public DeleteModel(EntertainmentCatalog.Models.EntertainmentCatalogContext context)
        {
            _context = context;
        }

        [BindProperty]
        public log Catalog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Catalog = await _context.log.FirstOrDefaultAsync(m => m.ID == id);

            if (Catalog == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Catalog = await _context.log.FindAsync(id);

            if (Catalog != null)
            {
                _context.log.Remove(Catalog);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
