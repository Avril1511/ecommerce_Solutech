using ecommerce_Solutech.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_Solutech.Models
{
    public class ItemDoPedido {
        [Key]
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int quantidade { get; set;}
        public double valor { get; set;}
        [ForeignKey("IdPedido")]
        public Pedido pedido { get; set;}

		[ForeignKey("IdProduto")]
        public Produto produto { get; set;}

	}

}
