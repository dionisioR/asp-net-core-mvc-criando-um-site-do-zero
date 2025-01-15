using LancheMac_SSMS.Models;

namespace LancheMac_SSMS.ViewModels {
    public class LancheListViewModel {
        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
