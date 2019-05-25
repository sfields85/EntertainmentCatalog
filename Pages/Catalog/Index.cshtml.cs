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
    public class IndexModel : PageModel
    {
        private readonly EntertainmentCatalog.Models.EntertainmentCatalogContext _context;

        public IndexModel(EntertainmentCatalog.Models.EntertainmentCatalogContext context)
        {
            _context = context;
        }

        public IList<log> Catalog { get;set; }

        public async Task OnGetAsync()
        {
            Catalog = await _context.log.ToListAsync();
        }
    }
}
