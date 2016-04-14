using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class LogExecution
    {
        public LogExecution()
        {
            this.LogExecutionExceptions = new List<LogExecutionException>();
        }

        public int id { get; set; }
        public int idOperadora { get; set; }
        public Nullable<System.DateTime> dtaExecution { get; set; }
        public System.DateTime dtaFiltroTransacoes { get; set; }
        public Nullable<int> qtdTransacoes { get; set; }
        public Nullable<decimal> vlTotalTransacoes { get; set; }
        public string statusExecution { get; set; }
        public Nullable<int> idLoginOperadora { get; set; }
        public Nullable<System.DateTime> dtaExecucaoInicio { get; set; }
        public Nullable<System.DateTime> dtaExecucaoFim { get; set; }
        public Nullable<System.DateTime> dtaFiltroTransacoesFinal { get; set; }
        public Nullable<System.DateTime> dtaExecucaoProxima { get; set; }
        public virtual ICollection<LogExecutionException> LogExecutionExceptions { get; set; }
        public virtual LoginOperadora LoginOperadora { get; set; }
    }
}
