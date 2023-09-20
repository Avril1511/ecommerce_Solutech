using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_Solutech.Models {
    public class Produto {
        [Key]
        public int? Id { get; set; }
        public string Nome { get; set; }
        public float Estoque { get; set; }
        public double Preco { get; set; }
        public DateTime VencimentoProduto { get; set; }
        public ICollection<ItemDoPedido> ItemDoPedidos { get; set; }
    }
}
