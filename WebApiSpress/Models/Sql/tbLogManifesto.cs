using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tbLogManifesto
    {
        public int idLog { get; set; }
        public System.DateTime dtLogInicio { get; set; }
        public string dsXmlEntrada { get; set; }
        public Nullable<short> cdRetorno { get; set; }
        public string dsRetorno { get; set; }
        public string dsMetodo { get; set; }
        public string dsXmlRetorno { get; set; }
        public Nullable<System.DateTime> dtLogFim { get; set; }
    }
}