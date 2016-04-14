using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class Cielo
    {
        public int id { get; set; }
        public System.DateTime dtaVenda { get; set; }
        public System.DateTime dtaPrevistaPagto { get; set; }
        public string descricao { get; set; }
        public string resumo { get; set; }
        public string cnpj { get; set; }
        public string numCartao { get; set; }
        public string nsu { get; set; }
        public string cdAutorizador { get; set; }
        public decimal valorTotal { get; set; }
        public decimal valorBruto { get; set; }
        public string rejeitado { get; set; }
        public decimal valorSaque { get; set; }
        public int idOperadora { get; set; }
        public int idBandeira { get; set; }
        public Nullable<System.DateTime> dtaRecebimento { get; set; }
        public int idTerminalLogico { get; set; }
        public virtual empresa empresa { get; set; }
        public virtual BandeiraPos BandeiraPos { get; set; }
        public virtual Operadora Operadora { get; set; }
    }
}
