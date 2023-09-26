

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ecommerce_Solutech.Models{
    public class Cliente{
        [Key]

        public int? Id { get; set; }
		[Required(ErrorMessage = "0 campos {0} é de preenchimento obrigatório")]
		[MaxLength(100)]
		public int? IdEndereco { get; set; }
        public string Nome { get; set; }
        [Required(ErrorMessage = "0 campo \"{0}\" é de preenchimento obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "0 campo {0} de ter uma data")]
        [DisplayName("Data de Nascimento")]
        public string email { get; set; }
        public string telefone { get; set;}
        
        [Required(ErrorMessage = "O campo \"{0}\" é de prenchimento obrigatório.")]
        [DisplayName("email")]
        [EmailAddress(ErrorMessage = "O campo \"{0}\"deve conter um endereço de email válido.")]
        [MaxLength(50, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres.")]

 
        public string login { get; set;}
        public string HashSenha { get; set;}

        [ForeignKey("IdEndereco")]
        public Endereco? Endereco { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }

    }
}
