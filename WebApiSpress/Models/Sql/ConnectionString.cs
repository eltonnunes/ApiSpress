using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class ConnectionString
    {
        public int Id { get; set; }
        public string ConnectionStrings { get; set; }
        public bool Status { get; set; }
        public string Rede { get; set; }
        public int Id_Grupo { get; set; }
        public virtual grupo_empresa grupo_empresa { get; set; }
    }
}
