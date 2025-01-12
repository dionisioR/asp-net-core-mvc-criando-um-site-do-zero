using System.ComponentModel.DataAnnotations;

namespace LancheMac_MsSQL.Models
{
    public class Categoria
    {
        [Key]
        [Display(Name ="Código")]
        public int cat_id { get; set; }

        [Display(Name ="Nome")]
        public string cat_nome { get; set; }

        [Display(Name ="Descrição")]
        public string cat_descricao { get; set; }

        public List<Lanche> lanches { get; set; }
    }
}
