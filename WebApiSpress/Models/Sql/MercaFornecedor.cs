using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class MercaFornecedor
    {
        public int IdMercaFornecedor { get; set; }
        public string CNPJ { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string EAN { get; set; }
        public string NCM { get; set; }
        public virtual fornecedor fornecedor { get; set; }
    }
}
