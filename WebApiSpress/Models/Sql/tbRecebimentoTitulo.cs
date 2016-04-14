using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSpress.Models.Sql
{
    public partial class tbRecebimentoTitulo
    {
        public int idRecebimentoTitulo { get; set; }
        public string nrCNPJ { get; set; }
        public string nrNSU { get; set; }
        public Nullable<System.DateTime> dtVenda { get; set; }
        public int cdAdquirente { get; set; }
        public string dsBandeira { get; set; }
        public Nullable<decimal> vlVenda { get; set; }
        public Nullable<byte> qtParcelas { get; set; }
        public System.DateTime dtTitulo { get; set; }
        public decimal vlParcela { get; set; }
        public byte nrParcela { get; set; }
        public string cdERP { get; set; }
        public Nullable<System.DateTime> dtBaixaERP { get; set; }
        public virtual tbAdquirente tbAdquirente { get; set; }
        public virtual empresa empresa { get; set; }
        //public virtual ICollection<RecebimentoParcela> RecebimentoParcelas { get; set; }
    }
}
