using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class BaneseCard
    {
        public int id { get; set; }
        public string operacao { get; set; }
        public System.DateTime dtaVenda { get; set; }
        public string nsu { get; set; }
        public string modalidade { get; set; }
        public int totalParcelas { get; set; }
        public decimal valorBruto { get; set; }
        public decimal valorLiquido { get; set; }
        public string cnpj { get; set; }
        public int idOperadora { get; set; }
        public int idBandeira { get; set; }
        public Nullable<System.DateTime> dtaRecebimento { get; set; }
        public Nullable<int> idTerminalLogico { get; set; }
        public virtual empresa empresa { get; set; }
        public virtual BandeiraPos BandeiraPos { get; set; }
        public virtual Operadora Operadora { get; set; }
    }
}
