﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ecommerce_Solutech;

#nullable disable

namespace ecommerce_Solutech.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230921172445_v5")]
    partial class v5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ecommerce_Solutech.Models.Cliente", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("HashSenha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("IdEndereco")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("login")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdEndereco");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("ecommerce_Solutech.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("int");

                    b.Property<string>("Municipio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeCidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeRua")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NumerodaCasa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdEndereco");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("ecommerce_Solutech.Models.ItemDoPedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("quantidade")
                        .HasColumnType("int");

                    b.Property<double>("valor")
                        .HasColumnType("double");

                    b.HasKey("IdPedido", "IdProduto");

                    b.HasIndex("IdProduto");

                    b.HasIndex("ProdutoId");

                    b.ToTable("itemDoPedido");
                });

            modelBuilder.Entity("ecommerce_Solutech.Models.Pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("int");

                    b.Property<double>("valorTotal")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEndereco");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("ecommerce_Solutech.Models.Produto", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Estoque")
                        .HasColumnType("float");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Preco")
                        .HasColumnType("double");

                    b.Property<DateTime>("VencimentoProduto")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("produtos");
                });

            modelBuilder.Entity("ecommerce_Solutech.Models.Cliente", b =>
                {
                    b.HasOne("ecommerce_Solutech.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("IdEndereco");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("ecommerce_Solutech.Models.Endereco", b =>
                {
                    b.HasOne("ecommerce_Solutech.Models.Endereco", "endereco")
                        .WithMany()
                        .HasForeignKey("IdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("endereco");
                });

            modelBuilder.Entity("ecommerce_Solutech.Models.ItemDoPedido", b =>
                {
                    b.HasOne("ecommerce_Solutech.Models.Pedido", "pedido")
                        .WithMany("ItemDoPedidos")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ecommerce_Solutech.Models.Produto", "produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ecommerce_Solutech.Models.Produto", null)
                        .WithMany("ItemDoPedidos")
                        .HasForeignKey("ProdutoId");

                    b.Navigation("pedido");

                    b.Navigation("produto");
                });

            modelBuilder.Entity("ecommerce_Solutech.Models.Pedido", b =>
                {
                    b.HasOne("ecommerce_Solutech.Models.Cliente", "cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ecommerce_Solutech.Models.Endereco", "endereco")
                        .WithMany()
                        .HasForeignKey("IdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");

                    b.Navigation("endereco");
                });

            modelBuilder.Entity("ecommerce_Solutech.Models.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("ecommerce_Solutech.Models.Pedido", b =>
                {
                    b.Navigation("ItemDoPedidos");
                });

            modelBuilder.Entity("ecommerce_Solutech.Models.Produto", b =>
                {
                    b.Navigation("ItemDoPedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
