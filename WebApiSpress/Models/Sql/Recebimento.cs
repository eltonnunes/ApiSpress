using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class Recebimento
    {
        public Recebimento()
        {
            this.RecebimentoParcelas = new List<RecebimentoParcela>();
        }

        public int id { get; set; }
        public int idBandeira { get; set; }
        public string cnpj { get; set; }
        public string nsu { get; set; }
        public string cdAutorizador { get; set; }
        public System.DateTime dtaVenda { get; set; }
        public decimal valorVendaBruta { get; set; }
        public Nullable<decimal> valorVendaLiquida { get; set; }
        public string loteImportacao { get; set; }
        public System.DateTime dtaRecebimento { get; set; }
        public int idLogicoTerminal { get; set; }
        public string codTituloERP { get; set; }
        public string codVendaERP { get; set; }
        public string codResumoVenda { get; set; }
        public Nullable<int> numParcelaTotal { get; set; }
        public virtual empresa empresa { get; set; }
        public virtual BandeiraPos BandeiraPos { get; set; }
        public virtual TerminalLogico TerminalLogico { get; set; }
        public virtual ICollection<RecebimentoParcela> RecebimentoParcelas { get; set; }
    }
}
