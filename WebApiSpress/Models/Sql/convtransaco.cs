using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class convtransaco
    {
        public decimal cod_trnsitef { get; set; }
        public decimal cod_sit { get; set; }
        public string codigo_proc { get; set; }
        public decimal parcelado { get; set; }
        public decimal cod_subfunc { get; set; }
        public decimal cod_trnweb { get; set; }
        public decimal cdmodoentrada { get; set; }
        public decimal operacaotef { get; set; }
        public Nullable<decimal> funcconv { get; set; }
        public decimal cod_func { get; set; }
        public virtual modoentrada modoentrada { get; set; }
        public virtual sitrede sitrede { get; set; }
        public virtual transaco transaco { get; set; }
    }
}
