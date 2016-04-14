using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class FitCard
    {
        public int id { get; set; }
        public int numero { get; set; }
        public Nullable<System.DateTime> data { get; set; }
        public string hora { get; set; }
        public string combustivel { get; set; }
        public decimal valorTotalLitros { get; set; }
        public decimal valor { get; set; }
        public decimal valorLitro { get; set; }
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
