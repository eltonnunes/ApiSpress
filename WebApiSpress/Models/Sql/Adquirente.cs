using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class Adquirente
    {
        public Adquirente()
        {
            this.TaxaAdministracaos = new List<TaxaAdministracao>();
            this.Bandeiras = new List<Bandeira>();
        }

        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public byte status { get; set; }
        public Nullable<System.DateTime> hraExecucao { get; set; }
        public virtual ICollection<TaxaAdministracao> TaxaAdministracaos { get; set; }
        public virtual ICollection<Bandeira> Bandeiras { get; set; }
    }
}
