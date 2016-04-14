using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tbRebimentoResumo
    {
        public int idRebimentoResumo { get; set; }
        public int cdAdquirente { get; set; }
        public int cdBandeira { get; set; }
        public short cdTipoProdutoTef { get; set; }
        public Nullable<int> cdTerminal { get; set; }
        public System.DateTime dtVenda { get; set; }
        public decimal vlVendaBruto { get; set; }
    }
}