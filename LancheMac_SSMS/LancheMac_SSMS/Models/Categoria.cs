namespace LancheMac_SSMS.Models {
    public class Categoria {
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
        public string Descricao { get; set; }

        // propriedade de navegação indicando que catigoria estará em vários lanches
        public List<Lanche> Lanches { get; set; }
    }
}
