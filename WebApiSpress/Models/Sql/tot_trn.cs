using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tot_trn
    {
        public string data_trn { get; set; }
        public string hora_trn { get; set; }
        public int idt_rede { get; set; }
        public string codlojasitef { get; set; }
        public Nullable<int> estado_trn { get; set; }
        public string tot_valor_trn { get; set; }
        public string tot_qtd { get; set; }
    }
}
