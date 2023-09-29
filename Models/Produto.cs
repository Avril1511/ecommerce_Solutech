using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_Solutech.Models {
    public class Produto {
        [Key]
        public int? Id { get; set; }
		[MaxLength(100, ErrorMessage = "O campo {0} Deve ter no Máximo {1}")]
		[MinLength(15, ErrorMessage = "O campo {0} Deve ter no Mínimo {1} caracteres.")]
        [Required(ErrorMessage = " O campo {0} é de preenchimento obrigatório")]
		public string Nome { get; set; }
		
        [Required(ErrorMessage = " O campo {0} é de preenchimento obrigatório")]
		public float Estoque { get; set; }
		
        [Required(ErrorMessage = " O campo {0} é de preenchimento obrigatório")]
		[Display(Name = "Preço")]
		public double Preco { get; set; }
		
        [Required(ErrorMessage = " O campo {0} é de preenchimento obrigatório")]
		[DataType(DataType.Date, ErrorMessage = "O campo {0} deve ter uma data válida")]
		public DateTime VencimentoProduto { get; set; }
        public ICollection<ItemDoPedido>? ItemDoPedidos { get; set; }
    }
}
