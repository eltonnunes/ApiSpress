using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class LogExecutionException
    {
        public int id { get; set; }
        public int idLogExecution { get; set; }
        public string textError { get; set; }
        public virtual LogExecution LogExecution { get; set; }
    }
}
