﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_Solutech.Models {
    public class Pedido {
        public int id { get; set; }

        public int IdEndereco { get; set; }

        public int IdCliente { get; set; }

        public Double valortotal { get; set; }

        public DateTime DataPedido { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set;}

        [ForeignKey("IdEndereco")]
        public Endereco endereco { get; set; }
    }
}