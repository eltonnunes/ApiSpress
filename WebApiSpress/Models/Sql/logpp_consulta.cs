using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class logpp_consulta
    {
        public decimal cod_sit { get; set; }
        public string data_trn { get; set; }
        public string nsu_sitef { get; set; }
        public string codlojasitef { get; set; }
        public string idt_terminal { get; set; }
        public decimal cod_trnweb { get; set; }
        public decimal estado_trn { get; set; }
        public string codigo_resp { get; set; }
        public string nsu_host { get; set; }
        public string documento { get; set; }
        public string descricao { get; set; }
        public Nullable<decimal> quantidade { get; set; }
        public string terminal_logico { get; set; }
        public string codigo_estab { get; set; }
        public string hora_trn { get; set; }
        public string codigoecupom { get; set; }
    }
}
