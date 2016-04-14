using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class pedido
    {
        public string nu_cnpjEmpresa { get; set; }
        public int id_grupo { get; set; }
        public int id_merca { get; set; }
        public decimal nu_qtd { get; set; }
        public Nullable<decimal> tx_icms { get; set; }
        public Nullable<decimal> tx_ipi { get; set; }
        public string tp_embalagem { get; set; }
        public decimal nu_qtdPorEmbalagem { get; set; }
        public System.DateTime dt_dataPedido { get; set; }
        public string nu_pedidoInterno { get; set; }
        public virtual empresa empresa { get; set; }
        public virtual grupo_empresa grupo_empresa { get; set; }
        public virtual merca merca { get; set; }
    }
}
