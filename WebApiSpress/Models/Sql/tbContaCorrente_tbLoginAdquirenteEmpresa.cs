using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tbContaCorrente_tbLoginAdquirenteEmpresa
    {
        public int cdContaCorrente { get; set; }
        public int cdLoginAdquirenteEmpresa { get; set; }
        public System.DateTime dtInicio { get; set; }
        public Nullable<System.DateTime> dtFim { get; set; }
        public virtual tbContaCorrente tbContaCorrente { get; set; }
        public virtual tbLoginAdquirenteEmpresa tbLoginAdquirenteEmpresa { get; set; }
    }
}