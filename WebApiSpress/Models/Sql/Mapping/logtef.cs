using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiSpress.Models.Sql.Mapping
{
    [Table("logtef", Schema = "dbo")]
    public class logtef
    {
        public Nullable<Decimal> cod_sit { get; set; }
        public string data_trn { get; set; }
        public string nsu_sitef { get; set; }
        public string codlojasitef { get; set; }
        public string idt_terminal { get; set; }
        public string hora_trn { get; set; }
        public string dthr_trn { get; set; }
        public Nullable<Decimal> cod_trnweb { get; set; }
        public Nullable<Decimal> cdmodoentrada { get; set; }
        public string valor_trn { get; set; }
        public string documento { get; set; }
        public string data_venc { get; set; }
        public Nullable<Decimal> idt_rede { get; set; }
        public Nullable<Decimal> idt_produto { get; set; }
        public Nullable<Decimal> estado_trn { get; set; }
        [Key]
        public string nsu_host { get; set; }
        public string codigo_resp { get; set; }
        public Nullable<Decimal> temporesprede { get; set; }
        public Nullable<Decimal> temporesppdv { get; set; }
        public Nullable<Decimal> idt_bandeira { get; set; }
        public string num_parcelas { get; set; }
        public string data_lanc { get; set; }
        public string codigo_proc { get; set; }
        public string codigo_estab { get; set; }
        public string cod_autoriz { get; set; }
        public string codmoeda { get; set; }
        public string operador { get; set; }
        public string supervisor { get; set; }
        public string datapend { get; set; }
        public string horapend { get; set; }
        public string datasonda { get; set; }
        public string horasonda { get; set; }
        public string cdrespsonda { get; set; }
        public string nsucanchost { get; set; }
        public string nsudesfsitef { get; set; }
        public Nullable<Decimal> origemestado { get; set; }
        public string usuariopend { get; set; }
        public string ipterminal { get; set; }
        public string datafiscal { get; set; }
        public string horafiscal { get; set; }
        public string cuponfiscal { get; set; }
        public string ipsitef { get; set; }
        public string codcli { get; set; }
        public Nullable<Decimal> captura { get; set; }
        public string taxa_embarque { get; set; }
        public string terminal_logico { get; set; }
        public string valor_saque { get; set; }
        public Nullable<Decimal> origem_trn { get; set; }
        public string nome_operadora { get; set; }
        public string cod_prod_valegas { get; set; }
        public string cod_oper_valegas { get; set; }
        public string tipocartao { get; set; }
        public Nullable<Decimal> trnecommerce { get; set; }
        public string cod_bandeira { get; set; }
        public string trnaprovadapp { get; set; }
        public string valordescontopp { get; set; }
        public string valor_estorno_parcial { get; set; }
        public string codigoissuer { get; set; }
        public string frentista { get; set; }
        public string cpf { get; set; }
        public Nullable<Decimal> se_cliente { get; set; }
        public string lote_fechado { get; set; }
        public string codigo_plano { get; set; }
        public string valorservico { get; set; }
        public string valorprincipal { get; set; }
        public string pagto_carne { get; set; }
        public string documento_sec { get; set; }
        public string moeda { get; set; }
        public string tipo_oper { get; set; }
        public string taxa_cobrada { get; set; }
        public string id_sitef { get; set; }
        public string cep { get; set; }
        public string celular { get; set; }
    }
}