using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class ValeCard
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public string comprador { get; set; }
        public string cd_autorizador { get; set; }
        public System.DateTime data { get; set; }
        public Nullable<decimal> valor { get; set; }
        public string cnpj { get; set; }
        public string parcelaTotal { get; set; }
        public string terminal { get; set; }
        public int idOperadora { get; set; }
        public int idBandeira { get; set; }
        public Nullable<System.DateTime> data_recebimento { get; set; }
        public int idTerminalLogico { get; set; }
        public virtual empresa empresa { get; set; }
        public virtual BandeiraPos BandeiraPos { get; set; }
        public virtual Operadora Operadora { get; set; }
    }
}
