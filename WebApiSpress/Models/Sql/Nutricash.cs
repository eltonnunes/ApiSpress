using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class Nutricash
    {
        public int id { get; set; }
        public string cdAutorizador { get; set; }
        public string status { get; set; }
        public System.DateTime dtaHora { get; set; }
        public string numCartao { get; set; }
        public string credenciado { get; set; }
        public decimal valor { get; set; }
        public string cnpj { get; set; }
        public int idOperadora { get; set; }
        public int idBandeira { get; set; }
        public Nullable<System.DateTime> dtaRecebimento { get; set; }
        public int idTerminalLogico { get; set; }
        public virtual empresa empresa { get; set; }
        public virtual BandeiraPos BandeiraPos { get; set; }
        public virtual Operadora Operadora { get; set; }
    }
}
