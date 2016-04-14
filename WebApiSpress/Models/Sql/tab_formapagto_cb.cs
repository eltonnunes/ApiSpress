using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tab_formapagto_cb
    {
        public tab_formapagto_cb()
        {
            this.conv_formapgto_cb = new List<conv_formapgto_cb>();
            this.logcbs = new List<logcb>();
        }

        public decimal formapagto { get; set; }
        public string descr_formapagto { get; set; }
        public virtual ICollection<conv_formapgto_cb> conv_formapgto_cb { get; set; }
        public virtual ICollection<logcb> logcbs { get; set; }
    }
}
