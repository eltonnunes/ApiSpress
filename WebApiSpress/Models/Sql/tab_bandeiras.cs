using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tab_bandeiras
    {
        public string cod_bandeira { get; set; }
        public string desc_bandeira { get; set; }
        public Nullable<System.DateTime> dth_ultima_at { get; set; }
    }
}
