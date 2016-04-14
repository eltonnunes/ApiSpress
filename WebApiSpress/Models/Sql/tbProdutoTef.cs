using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tbProdutoTef
    {
        public short cdProdutoTef { get; set; }
        public Nullable<short> cdTipoProdutoTef { get; set; }
        public string dsProdutoTef { get; set; }
        public virtual tbTipoProdutoTef tbTipoProdutoTef { get; set; }
    }
}
