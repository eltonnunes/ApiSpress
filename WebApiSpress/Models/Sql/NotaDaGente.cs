using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class NotaDaGente
    {
        public long id_NotaDaGente { get; set; }
        public int nu_pdv { get; set; }
        public Nullable<long> nu_protocolo { get; set; }
        public string ds_observacao { get; set; }
        public byte[] ds_arquivo { get; set; }
        public System.DateTime dt_movimento { get; set; }
        public System.DateTime dt_envio { get; set; }
        public byte fl_status { get; set; }
        public string nu_cnpj { get; set; }
    }
}
