using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class RedeMed
    {
        public int id { get; set; }
        public string cdAutorizador { get; set; }
        public string empresa { get; set; }
        public string nome { get; set; }
        public System.DateTime data { get; set; }
        public string numCartao { get; set; }
        public decimal valor { get; set; }
        public string parcela { get; set; }
        public string cancelada { get; set; }
        public string cnpj { get; set; }
        public int idOperadora { get; set; }
        public int idBandeira { get; set; }
        public Nullable<System.DateTime> dtaRecebimento { get; set; }
        public int idTerminalLogico { get; set; }
        public virtual empresa empresa1 { get; set; }
        public virtual BandeiraPos BandeiraPos { get; set; }
        public virtual Operadora Operadora { get; set; }
    }
}
