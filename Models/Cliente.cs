

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_Solutech.Models{
    public class Cliente{
        [Key]
        public int? Id { get; set; }
        public int IdEndereco { get; set; }
        public string Nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set;}
        public string login { get; set;}
        public string HashSenha { get; set;}

        [ForeignKey("IdEndereco")]
        public Endereco? Endereco { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }

    }
}
