using ecommerce_Solutech.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_Solutech.Models
{
    public class ItemDoPedido {
        [Key]
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "O campo {0} é que preenchimento obrigatório")] 
        public int quantidadepedido { get; set;}
        public double valor { get; set;}
		[Required(ErrorMessage = "O campo {0} é que preenchimento obrigatório")]


        [ForeignKey("IdPedido")]
        public Pedido pedido { get; set;}

		[ForeignKey("IdProduto")]
        public Produto produto { get; set;}

	}

}
