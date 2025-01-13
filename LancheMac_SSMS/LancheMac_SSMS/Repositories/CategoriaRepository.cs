using LancheMac_SSMS.Context;
using LancheMac_SSMS.Models;
using LancheMac_SSMS.Repositories.Interfaces;

namespace LancheMac_SSMS.Repositories {
    public class CategoriaRepository : ICategoriaRepository {

        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
