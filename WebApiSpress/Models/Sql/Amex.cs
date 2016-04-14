using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class Amex
    {
        public int id { get; set; }
        public System.DateTime dataRecebimento { get; set; }
        public System.DateTime dataVenda { get; set; }
        public string nsu { get; set; }
        public string cdAutorizador { get; set; }
        public string cnpj { get; set; }
        public string numCartao { get; set; }
        public int totalParcelas { get; set; }
        public decimal valorTotal { get; set; }
        public string numSubmissao { get; set; }
        public int idOperadora { get; set; }
        public int idBandeira { get; set; }
        public int idTerminalLogico { get; set; }
        public virtual empresa empresa { get; set; }
        public virtual BandeiraPos BandeiraPos { get; set; }
        public virtual Operadora Operadora { get; set; }
    }
}
