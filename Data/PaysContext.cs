using FinPaie.Models;
using Microsoft.EntityFrameworkCore;

namespace FinPaie.Data
{
    public class PaysContext : DbContext
    {
        public PaysContext(DbContextOptions<PaysContext> options)
            : base(options)
        {
        }

        public DbSet<Pays> Pays { get; set; }
    }
}
