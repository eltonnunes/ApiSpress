using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class logservcel
    {
        public decimal cod_sit { get; set; }
        public string data_trn { get; set; }
        public string nsu_sitef { get; set; }
        public string codlojasitef { get; set; }
        public string ident_pdv { get; set; }
        public string numero_logico_pdv { get; set; }
        public string nsu_host { get; set; }
        public Nullable<int> estado_trn { get; set; }
        public decimal cod_trnweb { get; set; }
        public string codigo_proc { get; set; }
        public string codigo_resp { get; set; }
        public Nullable<int> concessionaria { get; set; }
        public string cod_concessionaria { get; set; }
        public string area { get; set; }
        public string telefone { get; set; }
        public string dv_telefone { get; set; }
        public string hora_trn { get; set; }
        public string valor_trn { get; set; }
        public Nullable<int> nid { get; set; }
        public Nullable<int> versao { get; set; }
        public string codigo_if { get; set; }
        public string codigo_empresa_original { get; set; }
        public string codigo_empresa_filial { get; set; }
        public string codigo_estab_filial { get; set; }
        public string bit22 { get; set; }
        public string numcartao { get; set; }
        public string autorizacao { get; set; }
        public string h_codigo_resp { get; set; }
        public string h_data { get; set; }
        public string h_hora { get; set; }
        public string h_nsu_host { get; set; }
        public string h_codigo_estab_filial { get; set; }
        public string h_autorizacao { get; set; }
        public string h_doc_cancel { get; set; }
        public string h_data_cancel { get; set; }
        public string h_hora_cancel { get; set; }
        public string h_rede_autoriz { get; set; }
        public string h_nsu_sitef { get; set; }
        public Nullable<decimal> h_codigo_sit { get; set; }
        public Nullable<int> cod_trn_tef { get; set; }
        public string data_trn_tef { get; set; }
        public string cep { get; set; }
        public string autorizacao_concessionaria { get; set; }
        public string ipsitef { get; set; }
        public string datapend { get; set; }
        public string horapend { get; set; }
        public Nullable<decimal> origemestado { get; set; }
        public string usuariopend { get; set; }
        public string cod_operadora { get; set; }
        public string nome_operadora { get; set; }
        public string nome_filial { get; set; }
        public Nullable<decimal> codigo_trn { get; set; }
        public Nullable<decimal> codigo_subtrn_pdv { get; set; }
        public Nullable<decimal> codigo_subtrn_host { get; set; }
    }
}
