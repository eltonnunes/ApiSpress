using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class TerminalLogico
    {
        public TerminalLogico()
        {
            this.Recebimentoes = new List<Recebimento>();
        }

        public int idTerminalLogico { get; set; }
        public string dsTerminalLogico { get; set; }
        public int idOperadora { get; set; }
        public virtual Operadora Operadora { get; set; }
        public virtual ICollection<Recebimento> Recebimentoes { get; set; }
    }
}
