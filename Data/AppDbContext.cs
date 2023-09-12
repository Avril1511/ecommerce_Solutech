 
﻿using ecommerce_Solutech.Pages;
﻿using ecommerce_Solutech.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_Solutech {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions options) : base(options){
        }
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Endereco> endereco { get; set; }
        public DbSet<Produto> produtos { get; set; }

        public DbSet<Endereco> enderecos { get; set; }
 
    }     
}
