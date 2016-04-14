using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class produtosporrede
    {
        public decimal idt_rede { get; set; }
        public decimal idt_produto { get; set; }
        public string exibe { get; set; }
        public virtual produto produto { get; set; }
        public virtual rede rede { get; set; }
    }
}
