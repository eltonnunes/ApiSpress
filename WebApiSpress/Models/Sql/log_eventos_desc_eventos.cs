using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class log_eventos_desc_eventos
    {
        public log_eventos_desc_eventos()
        {
            this.log_eventos = new List<log_eventos>();
        }

        public string cod_evento { get; set; }
        public string desc_evento { get; set; }
        public virtual ICollection<log_eventos> log_eventos { get; set; }
    }
}
