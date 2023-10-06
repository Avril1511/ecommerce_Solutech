

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ecommerce_Solutech.Models{
    public class Cliente{
        [Key]
        public int? Id { get; set; }

		public int? IdEndereco { get; set; }


		[Required(ErrorMessage = "0 campo \"{0}\" é de preenchimento obrigatório")]
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
		[Required(ErrorMessage = "0 campo \"{0}\" é de preenchimento obrigatório")]
		public string telefone { get; set;}

		[Required(ErrorMessage = "0 campo \"{0}\" é de preenchimento obrigatório")]
		[MinLength(11, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
		public string Cpf { get; set;}
        public Endereco? Endereco { get; set; }

        public ICollection<Pedido>? Pedidos { get; set; }

    }
}
