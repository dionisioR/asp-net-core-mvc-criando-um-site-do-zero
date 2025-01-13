using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LancheMac_SSMS.Models {

    [Table("Categoria")]
    public class Categoria {
        [Key]
        public int CategoriaId { get; set; }

        [Required (ErrorMessage ="Informe o nome da categoria!")]
        [StringLength(100, ErrorMessage ="O tamanho máximo é de 100 caracteres")]
        [Display(Name ="Nome")]
        public string CategoriaNome { get; set; }

        [Required(ErrorMessage ="Informe a descrição da categoria")]
        [StringLength(200, ErrorMessage ="O tamanho máximo da descrição é de 200 caracteres")]
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }

        // propriedade de navegação indicando que catigoria estará em vários lanches
        public List<Lanche> Lanches { get; set; }
    }
}
