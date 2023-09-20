
﻿using ecommerce_Solutech.Pages;
﻿using ecommerce_Solutech.Pages;
﻿using ecommerce_Solutech.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_Solutech {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions options) : base(options) {
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemDoPedido>()
                .HasKey(e => new { e.IdPedido, e.IdProduto });

            modelBuilder.Entity<Pedido>()
                .HasOne<Cliente>(p => p.cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ItemDoPedido>()
			  .HasOne<Pedido>(ip => ip.pedido)
			  .WithMany(p => p.ItemDoPedidos)
			  .HasForeignKey(p => p.IdPedido)
			  .OnDelete(DeleteBehavior.Cascade);

			 modelBuilder.Entity<ItemDoPedido>()
			  .HasOne<Produto>(ip => ip.produto)
			  .WithMany()
			  .HasForeignKey(p => p.IdProduto)
			  .OnDelete(DeleteBehavior.Restrict);
		}


        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Endereco> endereco { get; set; }
        public DbSet<Produto> produtos { get; set; }       
        public DbSet<Endereco> enderecos { get; set; }
        public DbSet<ItemDoPedido> itemDoPedido { get; set; }

    }     
}
