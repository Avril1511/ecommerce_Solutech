using Microsoft.EntityFrameworkCore;

namespace ecommerce_Solutech {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions options) : base(options) {
        }
    }     
}
