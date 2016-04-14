using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class nfe_entrada
    {
        public string nu_cnpjEmpresa { get; set; }
        public string nu_cnpjCpfFornecedor { get; set; }
        public string nu_chave { get; set; }
        public string ds_fornecedor { get; set; }
        public string sg_uf { get; set; }
        public System.DateTime dt_emissao { get; set; }
        public Nullable<decimal> vl_icms { get; set; }
        public Nullable<decimal> vl_frete { get; set; }
        public Nullable<decimal> vl_desconto { get; set; }
        public Nullable<decimal> vl_ii { get; set; }
        public Nullable<decimal> vl_ipi { get; set; }
        public Nullable<decimal> vl_pis { get; set; }
        public Nullable<decimal> vl_cofins { get; set; }
        public Nullable<decimal> vl_outro { get; set; }
        public Nullable<decimal> vl_total { get; set; }
        public string ds_conteudo { get; set; }
        public long nu_nf { get; set; }
        public System.DateTime dt_cadastro { get; set; }
        public Nullable<System.DateTime> dt_exclusao { get; set; }
        public Nullable<long> fl_cancelada { get; set; }
        public string ds_protocolo { get; set; }
        public bool fl_statusInportacao { get; set; }
        public Nullable<System.DateTime> dt_inportacao { get; set; }
        public virtual empresa empresa { get; set; }
        public virtual fornecedor fornecedor { get; set; }
    }
}
