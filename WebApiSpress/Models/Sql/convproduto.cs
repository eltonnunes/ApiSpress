using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class convproduto
    {
        public decimal cod_sit { get; set; }
        public decimal operacaotef { get; set; }
        public string mascara_bin { get; set; }
        public decimal tam_cartao { get; set; }
        public decimal idt_produto { get; set; }
        public decimal idt_produto_local { get; set; }
        public virtual sitrede sitrede { get; set; }
        public virtual produto produto { get; set; }
    }
}
