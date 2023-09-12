 Add-Class-Cliente
﻿using ecommerce_Solutech.Pages;
﻿using ecommerce_Solutech.Models;
master
using Microsoft.EntityFrameworkCore;

namespace ecommerce_Solutech {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions options) : base(options) {
        }
 Add-Class-Cliente
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Endereco> endereco { get; set; }
       public DbSet<Produto> produtos { get; set; }
       
       public DbSet<Endereco> enderecos { get; set; }



master
    }     
}
