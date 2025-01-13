using LancheMac_SSMS.Models;

namespace LancheMac_SSMS.Repositories.Interfaces {
    public interface ICategoriaRepository {
        IEnumerable<Categoria> Categorias { get; }
    }
}
