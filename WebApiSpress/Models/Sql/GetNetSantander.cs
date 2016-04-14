using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class GetNetSantander
    {
        public int id { get; set; }
        public string bandeira { get; set; }
        public string produto { get; set; }
        public string descricaoTransacao { get; set; }
        public Nullable<System.DateTime> dtaTransacao { get; set; }
        public Nullable<System.DateTime> hraTransacao { get; set; }
        public System.DateTime dtahraTransacao { get; set; }
        public string numCartao { get; set; }
        public string numCv { get; set; }
        public string numAutorizacao { get; set; }
        public decimal valorTotalTransacao { get; set; }
        public int totalParcelas { get; set; }
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
