using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class Recebimento_Original
    {
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
    }
}
