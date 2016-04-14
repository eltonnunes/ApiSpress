using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class PDV
    {
        public PDV()
        {
            this.ConciliacaoPagamentos = new List<ConciliacaoPagamento>();
            this.ConciliacaoVendas = new List<ConciliacaoVenda>();
        }

        public int IdPDV { get; set; }
        public string CNPJjFilial { get; set; }
        public string DecricaoPdv { get; set; }
        public string CodPdvERP { get; set; }
        public string CodPdvHostPagamento { get; set; }
        public byte cdGrupo { get; set; }
        public virtual ICollection<ConciliacaoPagamento> ConciliacaoPagamentos { get; set; }
        public virtual ICollection<ConciliacaoVenda> ConciliacaoVendas { get; set; }
        public virtual empresa empresa { get; set; }
    }
}
