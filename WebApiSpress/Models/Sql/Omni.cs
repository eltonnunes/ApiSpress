using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class Omni
    {
        public int id { get; set; }
        public System.DateTime dtaTransacao { get; set; }
        public string descricao { get; set; }
        public string produto { get; set; }
        public string numCpf { get; set; }
        public string numCartao { get; set; }
        public decimal valorTotal { get; set; }
        public string metodo { get; set; }
        public string situacao { get; set; }
        public string cdAutorizacao { get; set; }
        public string usuario { get; set; }
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
