using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class GoodCard
    {
        public int id { get; set; }
        public string lancamento { get; set; }
        public System.DateTime dtaHora { get; set; }
        public int qtdTotalParcelas { get; set; }
        public string lote { get; set; }
        public string cnpj { get; set; }
        public string numCartao { get; set; }
        public string redeCaptura { get; set; }
        public decimal valorTransacao { get; set; }
        public decimal valorReembolso { get; set; }
        public decimal valorDescontado { get; set; }
        public System.DateTime dtaRecebimento { get; set; }
        public int idOperadora { get; set; }
        public int idBandeira { get; set; }
        public int idTerminalLogico { get; set; }
        public virtual empresa empresa { get; set; }
        public virtual BandeiraPos BandeiraPos { get; set; }
        public virtual Operadora Operadora { get; set; }
    }
}
