using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tbNewsGrupos
    {
        public tbNewsGrupos()
        {
            this.webpages_Users = new List<webpages_Users>();
            this.tbCatalogoes = new List<tbCatalogo>();
        }

        public int cdNewsGrupo { get; set; }
        public int cdEmpresaGrupo { get; set; }
        public string dsNewsGrupo { get; set; }
        public virtual ICollection<webpages_Users> webpages_Users { get; set; }
        public virtual ICollection<tbCatalogo> tbCatalogoes { get; set; }
    }
}