
using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tbNews
    {
        public tbNews()
        {
            this.tbNewsStatus = new List<tbNewsStatus>();
        }

        public int idNews { get; set; }
        public string dsNews { get; set; }
        public System.DateTime dtNews { get; set; }
        public Nullable<int> cdEmpresaGrupo { get; set; }
        public short cdCatalogo { get; set; }
        public short cdCanal { get; set; }
        public string cdReporter { get; set; }
        public Nullable<System.DateTime> dtEnvio { get; set; }
        public virtual tbCanal tbCanal { get; set; }
        public virtual tbCatalogo tbCatalogo { get; set; }
        public virtual ICollection<tbNewsStatus> tbNewsStatus { get; set; }
    }
}