using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class agendamento_finalizado
    {
        public string modulo { get; set; }
        public string data_exe { get; set; }
        public string status { get; set; }
        public string node_id { get; set; }
        public string task_name { get; set; }
    }
}
