using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_Solutech.Models {
    public class Produto {
        [Key]
        public int? Id { get; set; }
		[MaxLength(100, ErrorMessage = "O campo {Nome} Deve ter no Máximo {1}")]
		[MinLength(50, ErrorMessage = "O campo {Nome} Deve ter no Mínimo {1} caracteres.")]
		public string Nome { get; set; }
        public float Estoque { get; set; }
        public double Preco { get; set; }
		[DataType(DataType.Date, ErrorMessage = "O campo {Vencimento do Produto} deve ter uma data válida")]
		public DateTime VencimentoProduto { get; set; }
        public ICollection<ItemDoPedido> ItemDoPedidos { get; set; }
    }
}
