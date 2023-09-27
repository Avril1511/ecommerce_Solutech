using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_Solutech.Models {
    public class Endereco {
        [Key]
        public int Id { get; set; }


		[RegularExpression(@"[0-9]{8}", ErrorMessage = "O campo {0} deve ser preenchido com 8 digitos numéricos")]
		public string Cep { get; set; }

		[Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
		[MaxLength(100, ErrorMessage = "O campo {0} deve ter tamanho igual a {1}")]
		[MinLength(50, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
		[Display(Name = "Nome da Cidade")]
		public string NomeCidade { get; set; }

		[Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
		[MaxLength(100, ErrorMessage = "O campo {0} deve ter tamanho igual a {1}")]
		[MinLength(50, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
		public string Municipio { get; set; }

		[Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
		[MaxLength(100, ErrorMessage = "O campo {0} deve ter tamanho igual a {1}")]
		[MinLength(50, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
		[Display(Name = "Nome da Rua")]
		public string NomeRua {  get; set; }

		[Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
		[MaxLength(100, ErrorMessage = "O campo {0} deve ter tamanho igual a {1}")]
		[MinLength(50, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
		public string Bairro { get; set; }

		[Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
		[MaxLength(2, ErrorMessage = "O campo {0} deve ter tamanho igual a {1}")]
		[MinLength(2, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
		public string Estado { get; set; }

		[Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        public string NumerodaCasa { get; set; }
        [ForeignKey("IdEndereco")]
        public Endereco endereco { get; set; }

    }

}
