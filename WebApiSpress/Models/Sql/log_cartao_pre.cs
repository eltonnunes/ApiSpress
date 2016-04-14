using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class log_cartao_pre
    {
        public decimal cod_sit { get; set; }
        public string data_sitef { get; set; }
        public string nsu_sitef { get; set; }
        public string codlojasitef { get; set; }
        public string dthr_trn { get; set; }
        public string ident_pdv { get; set; }
        public string numero_logico_pdv { get; set; }
        public string nsu_host { get; set; }
        public Nullable<decimal> estado_trn { get; set; }
        public Nullable<decimal> cod_trn { get; set; }
        public string cod_proc { get; set; }
        public string cod_resposta { get; set; }
        public string hora { get; set; }
        public string valor { get; set; }
        public string num_cartao { get; set; }
        public Nullable<decimal> nid_msg { get; set; }
        public Nullable<decimal> num_controle { get; set; }
        public Nullable<decimal> versao { get; set; }
        public string cod_estabelecimento { get; set; }
        public string cod_autorizacao { get; set; }
        public string data_host { get; set; }
        public string hora_host { get; set; }
        public string data_fiscal { get; set; }
        public string hora_fiscal { get; set; }
        public string cupom_fiscal { get; set; }
        public string cod_operador { get; set; }
        public string cod_supervisor { get; set; }
        public string doc_original { get; set; }
        public string cupom_fiscal_cancel { get; set; }
        public string data_cancel { get; set; }
        public string hora_cancel { get; set; }
        public string nsu_sitef_cancel { get; set; }
        public string cod_produto { get; set; }
        public Nullable<decimal> forma_entrada_cartao { get; set; }
        public string flag_se_cartao_novo { get; set; }
        public string flag_gerou_alerta { get; set; }
        public string flag_aprovado_valor_menor { get; set; }
        public string range_inicial_lote { get; set; }
        public string range_final_lote { get; set; }
        public string fabricante { get; set; }
        public string data_lote { get; set; }
        public Nullable<decimal> qtde_forma_pagto { get; set; }
        public string forma_pagamento_1 { get; set; }
        public string valor_pagamento_1 { get; set; }
        public string servico_tef_z_1 { get; set; }
        public string forma_pagamento_2 { get; set; }
        public string valor_pagamento_2 { get; set; }
        public string servico_tef_z_2 { get; set; }
        public string forma_pagamento_3 { get; set; }
        public string valor_pagamento_3 { get; set; }
        public string servico_tef_z_3 { get; set; }
        public string forma_pagamento_4 { get; set; }
        public string valor_pagamento_4 { get; set; }
        public string servico_tef_z_4 { get; set; }
        public Nullable<decimal> captura { get; set; }
        public string ipsitef { get; set; }
        public string datapend { get; set; }
        public string horapend { get; set; }
        public Nullable<decimal> origemestado { get; set; }
        public string usuariopend { get; set; }
        public Nullable<decimal> temporesprede { get; set; }
        public Nullable<decimal> temporesppdv { get; set; }
        public string valor_compra { get; set; }
        public string valor_total_bonus { get; set; }
        public string pontos { get; set; }
        public Nullable<decimal> idt_rede { get; set; }
        public string ipterminal { get; set; }
        public string cod_cliente { get; set; }
        public Nullable<decimal> se_cliente { get; set; }
        public string nome_produto { get; set; }
        public string frentista { get; set; }
        public string id_fornecedor { get; set; }
        public string nome_fornecedor { get; set; }
        public string nsu_reserva { get; set; }
        public string portador { get; set; }
        public string placa_veiculo { get; set; }
        public string tipo_veiculo { get; set; }
        public string ano_veiculo { get; set; }
    }
}
