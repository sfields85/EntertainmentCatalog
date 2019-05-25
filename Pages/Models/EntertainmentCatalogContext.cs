using Microsoft.EntityFrameworkCore;

namespace EntertainmentCatalog.Models
{
    public class EntertainmentCatalogContext : DbContext
    {
        public EntertainmentCatalogContext (DbContextOptions<EntertainmentCatalogContext> options)
            : base(options)
        {
        }

        public DbSet<EntertainmentCatalog.Models.log> log { get; set; }
    }
}