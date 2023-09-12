using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ecommerce_Solutech.Pages{
    public class Cliente{
        public string Nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set;}
        public string login { get; set;}
        public string HashSenha { get; set;}

        public Endreco Endreco { get; set; }
    }
}
