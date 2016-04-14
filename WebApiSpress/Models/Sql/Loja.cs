using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class Loja
    {
        public Loja()
        {
            this.usuarios = new List<usuario>();
        }

        public string CodLojaSitef { get; set; }
        public string Descr_Loja { get; set; }
        public string cdestasodex { get; set; }
        public string cnpj { get; set; }
        public string cod_uf { get; set; }
        public Nullable<decimal> last_update { get; set; }
        public Nullable<decimal> se_cliente { get; set; }
        public virtual uf uf { get; set; }
        public virtual ICollection<usuario> usuarios { get; set; }
    }
}
