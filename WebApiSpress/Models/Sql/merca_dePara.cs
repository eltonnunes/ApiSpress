using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class merca_dePara
    {
        public int id_grupo { get; set; }
        public string cnpjFornecedor { get; set; }
        public int cd_xProd { get; set; }
        public string ds_xProd { get; set; }
        public Nullable<int> id_Merca { get; set; }
        public string cd_Ean13 { get; set; }
        public virtual grupo_empresa grupo_empresa { get; set; }
        public virtual fornecedor fornecedor { get; set; }
    }
}
