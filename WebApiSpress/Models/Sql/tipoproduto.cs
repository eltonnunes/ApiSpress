using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tipoproduto
    {
        public tipoproduto()
        {
            this.produtos = new List<produto>();
        }

        public decimal idt_tipoprd { get; set; }
        public string descr_prd { get; set; }
        public string exibe { get; set; }
        public virtual ICollection<produto> produtos { get; set; }
    }
}
