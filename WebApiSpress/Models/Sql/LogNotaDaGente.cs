using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class LogNotaDaGente
    {
        public long id_LogNotaDaGente { get; set; }
        public Nullable<int> nu_pdv { get; set; }
        public Nullable<long> nu_protocolo { get; set; }
        public string ds_observacao { get; set; }
        public Nullable<System.DateTime> dt_movimento { get; set; }
        public Nullable<System.DateTime> dt_envio { get; set; }
        public Nullable<byte> fl_status { get; set; }
        public string nu_cnpj { get; set; }
    }
}
