using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class Carga
    {
        public int IdCargas { get; set; }
        public string CNPJFilial { get; set; }
        public Nullable<int> IdPDV { get; set; }
        public System.DateTime DtTransacao { get; set; }
        public System.DateTime DtImportacao { get; set; }
        public bool FlRecarga { get; set; }
        public Nullable<int> IdUserRecarga { get; set; }
        public System.DateTime DtRecarga { get; set; }
        public virtual empresa empresa { get; set; }
    }
}
