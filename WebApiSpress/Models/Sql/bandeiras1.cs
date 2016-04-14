using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class bandeiras1
    {
        public bandeiras1()
        {
            this.convbandeiras = new List<convbandeira>();
        }

        public decimal idt_bandeira { get; set; }
        public string descr_bandeira { get; set; }
        public virtual ICollection<convbandeira> convbandeiras { get; set; }
    }
}
