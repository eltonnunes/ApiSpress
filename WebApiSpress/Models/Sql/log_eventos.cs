using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class log_eventos
    {
        public log_eventos()
        {
            this.log_eventos_dados = new List<log_eventos_dados>();
        }

        public decimal id_log { get; set; }
        public string cod_evento { get; set; }
        public System.DateTime datahora { get; set; }
        public string cod_origem { get; set; }
        public string cod_usuario { get; set; }
        public decimal se_cliente { get; set; }
        public decimal id_schema { get; set; }
        public string aplicacao { get; set; }
        public virtual log_eventos_desc_eventos log_eventos_desc_eventos { get; set; }
        public virtual log_eventos_desc_origem log_eventos_desc_origem { get; set; }
        public virtual ICollection<log_eventos_dados> log_eventos_dados { get; set; }
    }
}
