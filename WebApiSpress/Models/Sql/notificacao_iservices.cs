using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class notificacao_iservices
    {
        public int id_Notificacao { get; set; }
        public string nm_Notificacao { get; set; }
        public string ds_Notificacao { get; set; }
        public string ds_Erro { get; set; }
        public string ds_CodigoErro { get; set; }
        public string ds_protocolo { get; set; }
        public System.DateTime dt_Notificacao { get; set; }
        public int tp_Prioridade { get; set; }
        public int tp_Status { get; set; }
        public int id_Servico { get; set; }
    }
}
