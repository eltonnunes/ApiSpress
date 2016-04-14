using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class email
    {
        public email()
        {
            this.statistics = new List<statistic>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string email1 { get; set; }
        public virtual ICollection<statistic> statistics { get; set; }
    }
}
