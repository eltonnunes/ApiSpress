using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class RedeCard
    {
        public int id { get; set; }
        public string nsu { get; set; }
        public string numCartao { get; set; }
        public System.DateTime dtaVenda { get; set; }
        public decimal valorBruto { get; set; }
        public int totalParcelas { get; set; }
        public string estabelecimento { get; set; }
        public string tipoCaptura { get; set; }
        public string vendaCancelada { get; set; }
        public string cnpj { get; set; }
        public int idOperadora { get; set; }
        public int idBandeira { get; set; }
        public Nullable<System.DateTime> dtaRecebimento { get; set; }
        public int idLogicoTerminal { get; set; }
        public string tipoVenda { get; set; }
        public Nullable<decimal> taxaAdministracao { get; set; }
        public string codResumoVenda { get; set; }
        public virtual empresa empresa { get; set; }
        public virtual BandeiraPos BandeiraPos { get; set; }
        public virtual Operadora Operadora { get; set; }
    }
}
