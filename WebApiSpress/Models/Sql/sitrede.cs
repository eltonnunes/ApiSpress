using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class sitrede
    {
        public sitrede()
        {
            this.convmodoentradas = new List<convmodoentrada>();
            this.convprodutoes = new List<convproduto>();
            this.convtransacoes = new List<convtransaco>();
            this.logtefs = new List<logtef>();
        }

        public decimal cod_sit { get; set; }
        public decimal idt_rede { get; set; }
        public string descr_sit { get; set; }
        public Nullable<decimal> tiposit { get; set; }
        public string logsit { get; set; }
        public virtual ICollection<convmodoentrada> convmodoentradas { get; set; }
        public virtual ICollection<convproduto> convprodutoes { get; set; }
        public virtual ICollection<convtransaco> convtransacoes { get; set; }
        public virtual ICollection<logtef> logtefs { get; set; }
        public virtual rede rede { get; set; }
    }
}
