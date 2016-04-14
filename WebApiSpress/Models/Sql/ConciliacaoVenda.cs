using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class ConciliacaoVenda
    {
        public int IdConciliacaoVenda { get; set; }
        public string CNPJFilial { get; set; }
        public int IdPdv { get; set; }
        public int IdBandeira { get; set; }
        public string NumeroTitulo { get; set; }
        public System.DateTime DtMovimentoVenda { get; set; }
        public decimal VlVenda { get; set; }
        public string NsuHostTef { get; set; }
        public int QuantidadeParcelas { get; set; }
        public int NumParcelas { get; set; }
        public virtual Bandeira Bandeira { get; set; }
        public virtual PDV PDV { get; set; }
    }
}
