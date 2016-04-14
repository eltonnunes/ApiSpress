using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class Bandeira1
    {
        public int id { get; set; }
        public string descricaoBandeira { get; set; }
        public int idGrupo { get; set; }
        public string codBandeiraERP { get; set; }
        public Nullable<int> codBandeiraHostPagamento { get; set; }
        public decimal taxaAdministracao { get; set; }
        public int idTipoPagamento { get; set; }
        public string sacado { get; set; }
        public Nullable<int> idAdquirente { get; set; }
        public virtual TipoPagamento TipoPagamento { get; set; }
        public virtual grupo_empresa grupo_empresa { get; set; }
    }
}
