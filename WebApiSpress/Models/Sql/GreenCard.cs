using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class GreenCard
    {
        public int id { get; set; }
        public System.DateTime dtaCompra { get; set; }
        public System.DateTime dtaVencimento { get; set; }
        public string cnpj { get; set; }
        public string cdAutorizador { get; set; }
        public decimal valorTransacao { get; set; }
        public System.DateTime dtaRecebimento { get; set; }
        public int idOperadora { get; set; }
        public int idBandeira { get; set; }
        public int idTerminalLogico { get; set; }
        public virtual empresa empresa { get; set; }
        public virtual BandeiraPos BandeiraPos { get; set; }
        public virtual Operadora Operadora { get; set; }
    }
}
