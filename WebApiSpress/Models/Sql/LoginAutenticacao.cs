using System;
using System.Collections.Generic;
using WebApiSpress.Models.Sql;

namespace WebApiSpress.Models.Sql
{
    public partial class LoginAutenticacao
    {
        public int idUsers { get; set; }
        public string token { get; set; }
        public Nullable<System.DateTime> dtValidade { get; set; }
        public virtual webpages_Users webpages_Users { get; set; }
    }
}
