using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tab_codtrnweb_cb
    {
        public decimal cod_trnweb { get; set; }
        public virtual transaco transaco { get; set; }
    }
}
