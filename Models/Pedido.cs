using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_Solutech.Models {
    public class Pedido {
        [Key]
        public int id { get; set; }
        
        public int IdEndereco { get; set; }

        public int IdCliente { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double valorTotal { get; set; }

        public DateTime DataPedido { get; set; } = DateTime.Now;

        [ForeignKey("IdCliente")]
        public Cliente cliente { get; set;}

        [ForeignKey("IdEndereco")]
        public Endereco endereco { get; set; } 

        public ICollection<ItemDoPedido> ItemDoPedidos { get; set; }     
        
    }
}
