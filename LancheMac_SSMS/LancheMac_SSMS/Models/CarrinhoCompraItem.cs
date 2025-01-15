using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LancheMac_SSMS.Models {
    [Table("CarrinhoCompraItens")]
    public class CarrinhoCompraItem {
        [Key]
        public int CarrinhoCompraItemId { get; set; }
        //FK
        public Lanche Lanche { get; set; }
        public int Quantidade { get; set; }

        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }
    }
}
