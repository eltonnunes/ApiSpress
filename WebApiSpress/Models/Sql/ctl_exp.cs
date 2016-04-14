using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class ctl_exp
    {
        public string id_cliente { get; set; }
        public decimal id_rede { get; set; }
        public string data_mvto { get; set; }
        public string dth_ult_trn { get; set; }
        public string hora_corte { get; set; }
        public string ind_corte { get; set; }
        public string ind_data { get; set; }
        public Nullable<decimal> se_cliente { get; set; }
    }
}
