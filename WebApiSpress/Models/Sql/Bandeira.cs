using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class Bandeira
    {
        public Bandeira()
        {
            this.ConciliacaoVendas = new List<ConciliacaoVenda>();
            this.ConciliacaoPagamentos = new List<ConciliacaoPagamento>();
            this.Adquirentes = new List<Adquirente>();
        }

        public int IdBandeira { get; set; }
        public string DescricaoBandeira { get; set; }
        public int IdGrupo { get; set; }
        public string CodBandeiraERP { get; set; }
        public decimal CodBandeiraHostPagamento { get; set; }
        public decimal TaxaAdministracao { get; set; }
        public int IdTipoPagamento { get; set; }
        public string Sacado { get; set; }
        public virtual grupo_empresa grupo_empresa { get; set; }
        public virtual ICollection<ConciliacaoVenda> ConciliacaoVendas { get; set; }
        public virtual ICollection<ConciliacaoPagamento> ConciliacaoPagamentos { get; set; }
        public virtual TipoPagamento TipoPagamento { get; set; }
        public virtual ICollection<Adquirente> Adquirentes { get; set; }
    }
}
