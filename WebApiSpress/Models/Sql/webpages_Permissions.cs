using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class webpages_Permissions
    {
        public int id_roles { get; set; }
        public int id_method { get; set; }
        public bool fl_principal { get; set; }
        public virtual webpages_Methods webpages_Methods { get; set; }
        public virtual webpages_Roles webpages_Roles { get; set; }
    }
}
