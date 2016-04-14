using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tbTipoProdutoTef
    {
        public tbTipoProdutoTef()
        {
            this.tbProdutoTefs = new List<tbProdutoTef>();
        }

        public short cdTipoProdutoTef { get; set; }
        public string dsTipoProdutoTef { get; set; }
        public virtual ICollection<tbProdutoTef> tbProdutoTefs { get; set; }
    }
}
