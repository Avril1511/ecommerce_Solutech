using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_Solutech.Models {
    public class Endereco {
        
        public int Id { get; set; }
        public string Cep { get; set; }
        public string NomeCidade { get; set; }
        public string Municipio { get; set; }
        public string NomeRua {  get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string NumerodaCasa { get; set; }
        [ForeignKey("IdEndereco")]
        public Endereco endereco { get; set; }

    }

}
