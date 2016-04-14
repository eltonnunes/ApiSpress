using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class Sodexo
    {
        public int id { get; set; }
        public Nullable<System.DateTime> dtaPagamento { get; set; }
        public System.DateTime dtaProcessamento { get; set; }
        public System.DateTime dtaTransacao { get; set; }
        public string rede { get; set; }
        public string descricao { get; set; }
        public string numCartao { get; set; }
        public string nsu { get; set; }
        public string cdAutorizador { get; set; }
        public string valorTotal { get; set; }
        public string cnpj { get; set; }
        public int idOperadora { get; set; }
        public int idBandeira { get; set; }
        public Nullable<System.DateTime> dtaRecebimento { get; set; }
        public int idTerminalLogico { get; set; }
        public virtual empresa empresa { get; set; }
        public virtual BandeiraPos BandeiraPos { get; set; }
        public virtual Operadora Operadora { get; set; }
    }
}
