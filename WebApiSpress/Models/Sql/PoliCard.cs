using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class PoliCard
    {
        public int id { get; set; }
        public System.DateTime data_transacao { get; set; }
        public string produto { get; set; }
        public string cnpj { get; set; }
        public System.DateTime prevRepasse { get; set; }
        public string usuario { get; set; }
        public string cd_autorizador { get; set; }
        public string tipo { get; set; }
        public decimal valorCredito { get; set; }
        public decimal valorDebito { get; set; }
        public decimal Saldo { get; set; }
        public string rede { get; set; }
        public int idOperadora { get; set; }
        public int idBandeira { get; set; }
        public Nullable<System.DateTime> data_recebimento { get; set; }
        public int idTerminalLogico { get; set; }
        public virtual empresa empresa { get; set; }
        public virtual BandeiraPos BandeiraPos { get; set; }
        public virtual Operadora Operadora { get; set; }
    }
}
