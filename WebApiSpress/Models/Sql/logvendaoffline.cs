using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class logvendaoffline
    {
        public decimal cod_sit { get; set; }
        public string cod_empresa { get; set; }
        public string data_trn { get; set; }
        public string hora_trn { get; set; }
        public string dataz { get; set; }
        public string cartao { get; set; }
        public string vencimento { get; set; }
        public string terminal { get; set; }
        public string valor_compra { get; set; }
        public string data_fiscal { get; set; }
        public string hora_fiscal { get; set; }
        public string cupon_fiscal { get; set; }
        public string id_voo { get; set; }
        public Nullable<decimal> rede_dest { get; set; }
        public Nullable<decimal> cod_resp_hdr { get; set; }
        public string mensagem { get; set; }
        public string cod_resposta { get; set; }
        public string nsu_host { get; set; }
        public string cod_estab { get; set; }
        public string cod_autoriz { get; set; }
        public string doc_cancel { get; set; }
        public string data_cancel { get; set; }
        public string hora_cancel { get; set; }
        public string rede_autz { get; set; }
        public string nsu_sitef { get; set; }
        public string cod_rede { get; set; }
        public string data_evento { get; set; }
        public string hora_evento { get; set; }
    }
}
