using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class log_eventos_desc_origem
    {
        public log_eventos_desc_origem()
        {
            this.log_eventos = new List<log_eventos>();
        }

        public string cod_origem { get; set; }
        public string desc_origem { get; set; }
        public virtual ICollection<log_eventos> log_eventos { get; set; }
    }
}
