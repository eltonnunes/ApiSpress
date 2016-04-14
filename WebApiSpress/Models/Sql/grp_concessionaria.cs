using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class grp_concessionaria
    {
        public grp_concessionaria()
        {
            this.concessionarias = new List<concessionaria>();
        }

        public decimal cod_grp_concessionaria { get; set; }
        public string descr_grp_concessionaria { get; set; }
        public virtual ICollection<concessionaria> concessionarias { get; set; }
    }
}
