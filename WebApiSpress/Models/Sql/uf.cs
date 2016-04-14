using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class uf
    {
        public uf()
        {
            this.Lojas = new List<Loja>();
        }

        public string cod_uf { get; set; }
        public string descr_uf { get; set; }
        public virtual ICollection<Loja> Lojas { get; set; }
    }
}
