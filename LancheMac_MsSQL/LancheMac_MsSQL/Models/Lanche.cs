using System.ComponentModel.DataAnnotations;

namespace LancheMac_MsSQL.Models {
    public class Lanche {

        [Key]
        [Display(Name ="Código")]
        public int lan_id { get; set; }

        [Display(Name ="Nome")]
        public string lan_nome { get; set; }

        [Display(Name ="Descrição Curta")]
        public string lan_descricaoCurta { get; set; }

        [Display(Name ="Descrição Detalhada")]
        public string lan_descricaoDetalhada { get; set; }

        [Display(Name ="Preço")]
        public decimal lan_preco { get; set; }

        [Display(Name ="URL Imagem")]
        public string lan_imagemUrl { get; set; }

        [Display(Name ="URL Imagem Thumbnail")]
        public string lan_imagemThumbnailUrl { get; set; }

        [Display(Name ="Lanche Preferido")]
        public bool lan_isLanchePreferido { get; set; }

        [Display(Name ="Estoque")]
        public bool lan_emEstoque { get; set; }

        // Mapeando FK
        public int cat_id {  get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
