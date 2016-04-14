using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class logconsulta
    {
        public decimal cod_sit { get; set; }
        public string data_trn { get; set; }
        public string nsu_sitef { get; set; }
        public string codlojasitef { get; set; }
        public string ident_pdv { get; set; }
        public string numero_logico_pdv { get; set; }
        public string hora_trn { get; set; }
        public Nullable<decimal> idt_produto { get; set; }
        public decimal cod_trnweb { get; set; }
        public Nullable<decimal> estado_trn { get; set; }
        public string codigo_resposta { get; set; }
        public string tipo_pessoa { get; set; }
        public string cgc_cpf { get; set; }
        public string num_banco { get; set; }
        public string num_agencia { get; set; }
        public string numerocheque { get; set; }
        public string valor { get; set; }
        public string nsu_host { get; set; }
        public string codigo_estab { get; set; }
        public Nullable<decimal> origemestado { get; set; }
        public string usuariopend { get; set; }
        public string datapend { get; set; }
        public string horapend { get; set; }
        public string ipsitef { get; set; }
        public string data_cheque { get; set; }
        public string tipo_entrada { get; set; }
        public string cmc7_inicial { get; set; }
        public string cmc7_final { get; set; }
        public string qtde_cheques { get; set; }
        public string numerochequefinal { get; set; }
        public string telefone_ddd { get; set; }
        public string telefone { get; set; }
        public string msg_resp { get; set; }
        public string cod_erro { get; set; }
        public string codigo_consulta { get; set; }
        public string servico { get; set; }
        public string usuario { get; set; }
        public string motivo_exclusao { get; set; }
        public string num_conta { get; set; }
    }
}
