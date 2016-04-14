using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class TaxaAdministracao
    {
        public int id { get; set; }
        public Nullable<int> idAdquirente { get; set; }
        public int idBandeira { get; set; }
        public string cnpj { get; set; }
        public string plano { get; set; }
        public int numParcela { get; set; }
        public string numBanco { get; set; }
        public string numAgencia { get; set; }
        public string numContaCorrente { get; set; }
        public Nullable<decimal> taxa { get; set; }
        public System.DateTime dtaAtualizacao { get; set; }
        public virtual empresa empresa { get; set; }
        public virtual Adquirente Adquirente { get; set; }
        public virtual BandeiraPos BandeiraPos { get; set; }
    }
}
