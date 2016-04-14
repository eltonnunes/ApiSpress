using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class TicketCar
    {
        public int id { get; set; }
        public System.DateTime dtaTransacao { get; set; }
        public string descricao { get; set; }
        public string tipoTransacao { get; set; }
        public string reembolso { get; set; }
        public string numCartao { get; set; }
        public string numOS { get; set; }
        public string mercadoria { get; set; }
        public string qtde { get; set; }
        public decimal valorUnitario { get; set; }
        public decimal valorDesconto { get; set; }
        public decimal valorBruto { get; set; }
        public string empresa { get; set; }
        public string cnpj { get; set; }
        public int idOperadora { get; set; }
        public int idBandeira { get; set; }
        public Nullable<System.DateTime> dtaRecebimento { get; set; }
        public int idTerminalLogico { get; set; }
        public virtual empresa empresa1 { get; set; }
        public virtual BandeiraPos BandeiraPos { get; set; }
        public virtual Operadora Operadora { get; set; }
    }
}
