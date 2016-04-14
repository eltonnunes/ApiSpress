using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class nfe_saida_new
    {
        public string nu_cnpj { get; set; }
        public string nu_cnpjCpfCliente { get; set; }
        public string nu_chave { get; set; }
        public string nm_Destinatario { get; set; }
        public string sg_uf { get; set; }
        public System.DateTime dt_Emissao { get; set; }
        public Nullable<decimal> vl_ICMS { get; set; }
        public Nullable<decimal> vl_Frete { get; set; }
        public Nullable<decimal> vl_Desconto { get; set; }
        public Nullable<decimal> vl_II { get; set; }
        public Nullable<decimal> vl_IPI { get; set; }
        public Nullable<decimal> vl_PIS { get; set; }
        public Nullable<decimal> vl_Cofins { get; set; }
        public Nullable<decimal> vl_Outro { get; set; }
        public Nullable<decimal> vl_Total { get; set; }
        public string ds_Conteudo { get; set; }
        public string nu_baseCnpjCliente { get; set; }
        public Nullable<bool> fl_GbCancelada { get; set; }
        public Nullable<System.DateTime> dt_cadastro { get; set; }
        public Nullable<System.DateTime> dt_exclusao { get; set; }
        public Nullable<System.DateTime> dt_devolucao { get; set; }
        public string ds_motivoDevolucao { get; set; }
        public Nullable<bool> fl_erro { get; set; }
    }
}
