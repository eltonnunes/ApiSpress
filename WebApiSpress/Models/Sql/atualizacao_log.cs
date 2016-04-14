using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class atualizacao_log
    {
        public System.DateTime data_atualizacao { get; set; }
        public string fonte_atualizacao { get; set; }
        public string msg_atualizacao { get; set; }
    }
}
