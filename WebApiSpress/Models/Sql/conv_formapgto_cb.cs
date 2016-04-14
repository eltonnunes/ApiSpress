using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class conv_formapgto_cb
    {
        public string formapagto_det { get; set; }
        public string desc_formapgto_det { get; set; }
        public Nullable<decimal> formapagto { get; set; }
        public virtual tab_formapagto_cb tab_formapagto_cb { get; set; }
    }
}
