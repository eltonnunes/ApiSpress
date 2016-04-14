using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class convmodoentrada
    {
        public decimal cod_sit { get; set; }
        public string bit_22 { get; set; }
        public decimal cdmodoentrada { get; set; }
        public virtual modoentrada modoentrada { get; set; }
        public virtual sitrede sitrede { get; set; }
    }
}
