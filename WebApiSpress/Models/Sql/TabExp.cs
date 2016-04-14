using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class TabExp
    {
        public string IdCliente { get; set; }
        public string UltimoArq { get; set; }
        public string Offset { get; set; }
        public Nullable<System.DateTime> dth_ultimaat { get; set; }
        public string dth_ult_trn { get; set; }
    }
}
