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
    public class DetailsModel : PageModel
    {
        private readonly EntertainmentCatalog.Models.EntertainmentCatalogContext _context;

        public DetailsModel(EntertainmentCatalog.Models.EntertainmentCatalogContext context)
        {
            _context = context;
        }

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
    }
}
