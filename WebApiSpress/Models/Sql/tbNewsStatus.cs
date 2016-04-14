using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tbNewsStatus
    {
        public int idNews { get; set; }
        public int id_users { get; set; }
        public Nullable<bool> flRecebido { get; set; }
        public Nullable<bool> flLido { get; set; }
        public virtual tbNews tbNews { get; set; }
        public virtual webpages_Users webpages_Users { get; set; }
    }
}