using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class ConciliacaoPagamentosPos
    {
        public int IdConciliacaoPagamento { get; set; }
        public string nu_cnpj { get; set; }
        public int IdOperadora { get; set; }
        public System.DateTime DtMovimentoPagto { get; set; }
        public decimal VlVenda { get; set; }
        public string CdAutorizador { get; set; }
        public int NumParcela { get; set; }
        public int TotalParcelas { get; set; }
        public virtual empresa empresa { get; set; }
        public virtual Operadora Operadora { get; set; }
    }
}
