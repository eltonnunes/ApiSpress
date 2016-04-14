using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class LogAcesso1
    {
        public Nullable<int> idUsers { get; set; }
        public Nullable<int> idController { get; set; }
        public Nullable<int> idMethod { get; set; }
        public System.DateTime dtAcesso { get; set; }
        public bool flMobile { get; set; }
        public string dsUserAgent { get; set; }
        public virtual webpages_Controllers webpages_Controllers { get; set; }
        public virtual webpages_Methods webpages_Methods { get; set; }
        public virtual webpages_Users webpages_Users { get; set; }
    }
}
