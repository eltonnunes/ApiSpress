using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class ConciliacaoRecebimento
    {
        public int id { get; set; }
        public Nullable<int> id_users { get; set; }
        public int idGrupo { get; set; }
        public byte mes { get; set; }
        public short ano { get; set; }
        public Nullable<System.DateTime> data { get; set; }
        public int quantidade { get; set; }
        public decimal valor { get; set; }
        public string observacao { get; set; }
        public byte status { get; set; }
        public virtual grupo_empresa grupo_empresa { get; set; }
        public virtual webpages_Users webpages_Users { get; set; }
    }
}
