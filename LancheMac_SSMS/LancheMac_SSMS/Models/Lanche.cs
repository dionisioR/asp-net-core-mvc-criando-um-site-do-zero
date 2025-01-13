using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LancheMac_SSMS.Models {

    [Table("Lanche")]
    public class Lanche {
        [Key]
        public int LancheId { get; set; }

        [Required(ErrorMessage ="O nome do lanche deve ser informado")]
        [Display(Name ="Nome do lanche")]
        [StringLength(80, MinimumLength = 10, ErrorMessage ="O nome deve ter de 10 à 80 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="A descrição do lanche deve ser informada")]
        [Display(Name ="Descrição do lanche")]
        [MinLength(20, ErrorMessage ="A descrição deve ter no mínimo 20 caracteres")]
        [MaxLength(50, ErrorMessage ="A descrição deve ter no máximo 50 caracteres")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage ="A descrição do erro deve ser informada")]
        [Display(Name ="Descrição detalhada do lanche")]
        [MinLength(20, ErrorMessage ="A descrição deve ter no mínimo 20 caracteres")]
        [MaxLength(200, ErrorMessage ="A descrição deve ter no máximo 200 caracteres")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage ="Informe o preço do lanche")]
        [Display(Name ="Preço")]
        [Column(TypeName ="decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage ="O preço deve estar entre 1 e 999,99")]
        public decimal Preco { get; set; }

        [Display(Name ="Caminho imagem normal")]
        [StringLength(200, ErrorMessage ="O valor do caminho normal deve ter no máximo 200 caracteres")]
        public string ImagemUrl { get; set; }

        [Display(Name ="Caminho imagem miniatura")]
        [StringLength(200, ErrorMessage ="O valor do campo imagem miniatura deve ter no máximo 200 caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name ="Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name ="Estoque")]
        public bool EmEstoque { get; set; }

        // Mapeando a FK
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
