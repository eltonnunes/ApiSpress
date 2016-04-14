using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSpress.Bibliotecas
{
    public static class UrlAPIs
    {
        // ADMINISTRAÇÃO
        public static string ADMINISTRACAO_LOGACESSO = "administracao/logacesso";
        public static string ADMINISTRACAO_PESSOA = "administracao/pessoa";
        public static string ADMINISTRACAO_TBCANAL = "administracao/tbcanal";
        public static string ADMINISTRACAO_TBCATALOGO = "administracao/tbcatalogo";
        public static string ADMINISTRACAO_TBEMPRESA = "administracao/tbempresa";
        public static string ADMINISTRACAO_TBEMPRESAFILIAL = "administracao/tbempresafilial";
        public static string ADMINISTRACAO_TBEMPRESAGRUPO = "administracao/tbempresagrupo";
        public static string ADMINISTRACAO_TBLOGACESSOUSUARIO = "administracao/tblogacessousuario";
        public static string ADMINISTRACAO_TBLOGERRO = "administracao/tblogerro";
        public static string ADMINISTRACAO_TBLOGMANIFESTO = "administracao/tblogmanifesto";
        public static string ADMINISTRACAO_TBNEWS = "administracao/tbnews";
        public static string ADMINISTRACAO_TBNEWSGRUPO = "administracao/tbnewsgrupo";
        public static string ADMINISTRACAO_TBNEWSSTATUS= "administracao/tbnewsstatus";
        public static string ADMINISTRACAO_WEBPAGESCONTROLLERS = "administracao/webpagescontrollers";
        public static string ADMINISTRACAO_WEBPAGESMEMBERSHIP = "administracao/webpagesmembership";
        public static string ADMINISTRACAO_WEBPAGESMETHODS = "administracao/webpagesmethods";
        public static string ADMINISTRACAO_WEBPAGESOPERMISSIONS = "administracao/webpagespermissions";
        public static string ADMINISTRACAO_WEBPAGESROLELEVELS = "administracao/webpagesrolelevels";
        public static string ADMINISTRACAO_WEBPAGESROLES = "administracao/webpagesroles";
        public static string ADMINISTRACAO_WEBPAGESUSERS = "administracao/webpagesusers";
        public static string ADMINISTRACAO_WEBPAGESUSERSINROLES = "administracao/webpagesusersinroles";

        // CARD
        public static string CARD_CONCILIACAOBANCARIA = "card/conciliacaobancaria";
        public static string CARD_TBADQUIRENTE = "card/tbadquirente";
        public static string CARD_TBBANCOPARAMETRO = "card/tbbancoparametro";
        public static string CARD_TBBANDEIRATEF = "card/tbbandeiratef";
        public static string CARD_TBCONTACORRENTE = "card/tbcontacorrente";
        public static string CARD_TBCONTACORRENTETBLOGINADQUIRENTEEMPRESA = "card/tbcontacorrentetbloginadquirenteempresa";
        public static string CARD_TBESTADOTRANSACAOTEF = "card/tbestadotransacaotef";
        public static string CARD_TBEXTRATO = "card/tbextrato";
        public static string CARD_TBLOGINADQUIRENTEEMPRESA = "card/tbloginadquirenteempresa";
        public static string CARD_TBMODOENTRADATEF = "card/tbmodoentradatef";
        public static string CARD_TBPRODUTOTEF = "card/tbprodutotef";
        public static string CARD_TBRECEBIMENTORESUMO = "card/tbrecebimentoresumo";
        public static string CARD_TBRECEBIMENTOTEF = "card/tbrecebimentotef";
        public static string CARD_TBREDETEF = "card/tbredetef";
        public static string CARD_TBSITUACAOREDETEF = "card/tbsituacaoredetef";
        public static string CARD_TBTIPOPRODUTOTEF = "card/tbtipoprodutotef";
        public static string CARD_TBTRANSACAOTEF = "card/tbtransacaotef";

        // CLIENTE
        public static string CLIENTE_EMPRESA = "cliente/empresa";
        public static string CLIENTE_GRUPOEMPRESA = "cliente/grupoempresa";

        // POS
        public static string POS_ADQUIRENTE = "pos/adquirente";
        public static string POS_AMEX = "pos/amex";
        public static string POS_BANDEIRA = "pos/bandeira";
        public static string POS_BANDEIRAPOS = "pos/bandeirapos";
        public static string POS_BANESECARD = "pos/banesecard";
        public static string POS_CIELO = "pos/cielo";
        public static string POS_CONCILIACAOPAGAMENTOPOS = "pos/conciliacaopagamentopos";
        public static string POS_CONCILIACAORECEBIMENTO = "pos/conciliacaorecebimento";
        public static string POS_FITCARD = "pos/fitcard";
        public static string POS_GETNETSANTANDER = "pos/getnetsantander";
        public static string POS_GOODCARD = "pos/goodcard";
        public static string POS_GREENCARD = "pos/greencard";
        public static string POS_LOGEXECUTION = "pos/logexecution";
        public static string POS_LOGEXECUTIONEXCEPTION = "pos/logexecutionexception";
        public static string POS_LOGINOPERADORA = "pos/loginoperadora";
        public static string POS_NUTRICASH = "pos/nutricash";
        public static string POS_OMNI = "pos/omni";
        public static string POS_OPERADORA = "pos/operadora";
        public static string POS_POLICARD = "pos/policard";
        public static string POS_RECEBIMENTO = "pos/recebimento";
        public static string POS_RECEBIMENTOPARCELA = "pos/recebimentoparcela";
        public static string POS_REDECARD = "pos/redecard";
        public static string POS_REDEMED = "pos/redemed";
        public static string POS_SODEXO = "pos/sodexo";
        public static string POS_TAXAADMINISTRACAO = "pos/taxaadministracao";
        public static string POS_TERMINALLOGICO = "pos/terminallogico";
        public static string POS_TICKETCAR = "pos/ticketcar";
        public static string POS_VALECARD = "pos/valecard";

        // TAX
        public static string TAX_TBCONTROLENSU = "tax/tbcontrolensu";
        public static string TAX_TBMANIFESTO = "tax/tbmanifesto";

        // UTIL
        public static string UTIL_BANCOS = "util/bancos";
        public static string UTIL_EXPORTAR = "util/exportar";
        public static string UTIL_UTILNFE = "util/utilnfe";
    }
}
