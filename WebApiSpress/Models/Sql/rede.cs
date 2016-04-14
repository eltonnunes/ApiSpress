using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class rede
    {
        public rede()
        {
            this.logtefs = new List<logtef>();
            this.produtosporredes = new List<produtosporrede>();
            this.sitredes = new List<sitrede>();
        }

        public decimal idt_rede { get; set; }
        public string descr_rede { get; set; }
        public string exibe { get; set; }
        public string disponivel { get; set; }
        public virtual ICollection<logtef> logtefs { get; set; }
        public virtual ICollection<produtosporrede> produtosporredes { get; set; }
        public virtual ICollection<sitrede> sitredes { get; set; }
    }
}
