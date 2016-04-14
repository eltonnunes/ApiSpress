using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class newsletter
    {
        public newsletter()
        {
            this.statistics = new List<statistic>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string descricao { get; set; }
        public Nullable<int> view { get; set; }
        public string html { get; set; }
        public virtual ICollection<statistic> statistics { get; set; }
    }
}
