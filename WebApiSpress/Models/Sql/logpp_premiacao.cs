using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class logpp_premiacao
    {
        public string codlojasitef { get; set; }
        public string codigoecupom { get; set; }
        public string data_trn { get; set; }
        public string hora_trn { get; set; }
        public string terminal_logico { get; set; }
        public string descricao { get; set; }
        public Nullable<decimal> quantidade { get; set; }
        public string versao { get; set; }
    }
}
