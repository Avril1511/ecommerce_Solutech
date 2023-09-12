using ecommerce_Solutech.Pages;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_Solutech {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions options) : base(options) {
        }
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Endereco> endereco { get; set; }
    }     
}
