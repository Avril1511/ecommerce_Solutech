using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_Solutech.Models {
    public class Endereco {
        [Key]
        public int Id { get; set; }
		[RegularExpression(@"[0-9]{8}", ErrorMessage = "O campo {Endereço} deve ser preenchido com 8 digitos numéricos")]
		public string Cep { get; set; }
		[MaxLength(100, ErrorMessage = "O campo {Nome da Cidade} deve ter tamanho igual a {1}")]
		[MinLength(50, ErrorMessage = "O campo {Nome da Cidade} deve ter no mínimo {1} caracteres.")]
		public string NomeCidade { get; set; }
		[MaxLength(100, ErrorMessage = "O campo {Municipio} deve ter tamanho igual a {1}")]
		[MinLength(50, ErrorMessage = "O campo {Municipio} deve ter no mínimo {1} caracteres.")]

		public string Municipio { get; set; }
		[MaxLength(100, ErrorMessage = "O campo {Nome da Rua} deve ter tamanho igual a {1}")]
		[MinLength(50, ErrorMessage = "O campo {Nome da Rua} deve ter no mínimo {1} caracteres.")]

		public string NomeRua {  get; set; }
		[MaxLength(100, ErrorMessage = "O campo {Bairro} deve ter tamanho igual a {1}")]
		[MinLength(50, ErrorMessage = "O campo {Bairro} deve ter no mínimo {1} caracteres.")]

		public string Bairro { get; set; }
		[MaxLength(100, ErrorMessage = "O campo {Estado} deve ter tamanho igual a {1}")]
		[MinLength(50, ErrorMessage = "O campo {Estado} deve ter no mínimo {1} caracteres.")]

		public string Estado { get; set; }
        public string NumerodaCasa { get; set; }
        [ForeignKey("IdEndereco")]
        public Endereco endereco { get; set; }

    }

}
