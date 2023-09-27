

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ecommerce_Solutech.Models{
    public class Cliente{
        [Key]
        public int? Id { get; set; }

		public int? IdEndereco { get; set; }


		[Required(ErrorMessage = "0 campos {0} é de preenchimento obrigatório")]
		public string Nome { get; set; }


        [Required(ErrorMessage = "0 campo \"{0}\" é de preenchimento obrigatório")]
        [EmailAddress(ErrorMessage = "O campo \"{0}\" é de prenchimento obrigatório")]
		[DisplayName("E-mail")]
		public string email { get; set; }

		[Required(ErrorMessage = "0 campo \"{0}\" é de preenchimento obrigatório")]
		[DataType(DataType.Date, ErrorMessage = "0 campo {0} de ter uma data")]
		[DisplayName("Data de Nascimento")]
		public DateTime DataNascimento { get; set; }

		
		[MinLength(11, ErrorMessage = "O campo \"{0}\" deve conter no máximo {1} caracteres.")]
        [DisplayName("Telefone")]

		public string telefone { get; set;}


        [Required(ErrorMessage = "O campo \"{0}\" é de prenchimento obrigatório.")]
        [MaxLength(50, ErrorMessage = "O campo \"{0}\" deve conter no minimo {8} caracteres.")]
		[DisplayName("Login")]
        public string login { get; set;}

		[MinLength(8, ErrorMessage = "O campo {0} deve ter no mínimo {6} caracteres.")]
		[DisplayName("HasSenha")]
		public string HashSenha { get; set;}


        public Endereco? Endereco { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }

    }
}
