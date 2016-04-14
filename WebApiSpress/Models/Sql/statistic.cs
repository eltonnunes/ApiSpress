using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class statistic
    {
        public int id { get; set; }
        public int idNewsletter { get; set; }
        public int idEmails { get; set; }
        public Nullable<int> idLinks { get; set; }
        public virtual email email { get; set; }
        public virtual link link { get; set; }
        public virtual newsletter newsletter { get; set; }
    }
}
