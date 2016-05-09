using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSpress.Models.Object
{
    public class TitulosExpress
    { 
        //public int idRecebimentoTitulo { get; set; }
        public string nrCNPJ { get; set; }
        public string nrNSU { get; set; }
        public Nullable<System.DateTime> dtVenda { get; set; }
        //public int cdAdquirente { get; set; }
        public string dsBandeira { get; set; }
        public Nullable<double> vlVenda { get; set; }
        public Nullable<int> qtParcelas { get; set; }
        public System.DateTime dtTitulo { get; set; }
        public double vlParcela { get; set; }
        public int nrParcela { get; set; }
        public string cdERP { get; set; }
        public string cdSacado { get; set; }
        public Nullable<System.DateTime> dtBaixaERP { get; set; }
    }

}
