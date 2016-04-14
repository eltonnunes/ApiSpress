using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class produto
    {
        public produto()
        {
            this.convprodutoes = new List<convproduto>();
            this.produtosporredes = new List<produtosporrede>();
        }

        public decimal idt_produto { get; set; }
        public decimal idt_tipoprd { get; set; }
        public string descr_produto { get; set; }
        public string exibe { get; set; }
        public string selbandeira { get; set; }
        public virtual ICollection<convproduto> convprodutoes { get; set; }
        public virtual tipoproduto tipoproduto { get; set; }
        public virtual ICollection<produtosporrede> produtosporredes { get; set; }
    }
}
