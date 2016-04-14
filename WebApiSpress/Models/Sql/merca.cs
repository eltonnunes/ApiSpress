using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class merca
    {
        public merca()
        {
            this.pedidoes = new List<pedido>();
        }

        public int id_Merca { get; set; }
        public int id_grupo { get; set; }
        public string ds_produto { get; set; }
        public string cd_codigoInterno { get; set; }
        public virtual grupo_empresa grupo_empresa { get; set; }
        public virtual ICollection<pedido> pedidoes { get; set; }
    }
}
