using LancheMac_SSMS.Models;
using Microsoft.EntityFrameworkCore;

namespace LancheMac_SSMS.Context {
    public class AppDbContext : DbContext {

        // Construtor
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
    }
}
