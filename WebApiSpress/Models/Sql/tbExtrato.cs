using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tbExtrato
    {
        public tbExtrato()
        {
            this.RecebimentoParcelas = new List<RecebimentoParcela>();
        }

        public int idExtrato { get; set; }
        public int cdContaCorrente { get; set; }
        public string nrDocumento { get; set; }
        public System.DateTime dtExtrato { get; set; }
        public string dsDocumento { get; set; }
        public Nullable<decimal> vlMovimento { get; set; }
        public string dsTipo { get; set; }
        public string dsArquivo { get; set; }
        public virtual tbContaCorrente tbContaCorrente { get; set; }
        public virtual ICollection<RecebimentoParcela> RecebimentoParcelas { get; set; }
    }
}