using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSpress.Models.Object
{
    public class ParamBaixa
    {
        public int idRecebimentoTitulo { get; set; }
        public string cdERP { get; set; }
        public string cdBanco { get; set; }
        public string nrAgencia { get; set; }
        public string nrConta { get; set; }
        public string nrNSU { get; set; }
        public DateTime dtaRecebimentoEfetivo { get; set; }
        public DateTime dtVenda { get; set; }
    }
}
