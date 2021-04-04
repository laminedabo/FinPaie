using Microsoft.EntityFrameworkCore;
using FinPaie.Models;

namespace FinPaie.Data
{
    public class CategorieSalarieContext : DbContext
    {
        public CategorieSalarieContext(DbContextOptions<CategorieSalarieContext> options)
            :base(options)
        {
        }

        public DbSet<CategorieSalarie> CategorieSalarie { get; set; }
    }
}
