using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class link
    {
        public link()
        {
            this.statistics = new List<statistic>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public Nullable<int> view { get; set; }
        public virtual ICollection<statistic> statistics { get; set; }
    }
}
