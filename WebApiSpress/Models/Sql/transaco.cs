using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class transaco
    {
        public transaco()
        {
            this.convtransacoes = new List<convtransaco>();
            this.logcbs = new List<logcb>();
            this.logtefs = new List<logtef>();
            this.tipo_transacao = new List<tipo_transacao>();
        }

        public decimal cod_trnweb { get; set; }
        public string descr_trn { get; set; }
        public string descr_trn_abrev { get; set; }
        public virtual ICollection<convtransaco> convtransacoes { get; set; }
        public virtual ICollection<logcb> logcbs { get; set; }
        public virtual ICollection<logtef> logtefs { get; set; }
        public virtual tab_codtrnweb_cb tab_codtrnweb_cb { get; set; }
        public virtual ICollection<tipo_transacao> tipo_transacao { get; set; }
    }
}
