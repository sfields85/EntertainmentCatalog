using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntertainmentCatalog.Models;

namespace EntertainmentCatalog.Pages.Catalog
{
    public class EditModel : PageModel
    {
        private readonly EntertainmentCatalog.Models.EntertainmentCatalogContext _context;

        public EditModel(EntertainmentCatalog.Models.EntertainmentCatalogContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Catalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogExists(Catalog.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CatalogExists(int id)
        {
            return _context.log.Any(e => e.ID == id);
        }
    }
}
