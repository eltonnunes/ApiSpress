using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tipo_transacao
    {
        public tipo_transacao()
        {
            this.transacoes = new List<transaco>();
        }

        public decimal tipo_id { get; set; }
        public string descricao { get; set; }
        public string exibe { get; set; }
        public virtual ICollection<transaco> transacoes { get; set; }
    }
}
