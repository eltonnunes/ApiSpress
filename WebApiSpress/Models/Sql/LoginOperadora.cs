using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class LoginOperadora
    {
        public LoginOperadora()
        {
            this.LogExecutions = new List<LogExecution>();
        }

        public int id { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public Nullable<System.DateTime> data_alteracao { get; set; }
        public bool status { get; set; }
        public string cnpj { get; set; }
        public int idOperadora { get; set; }
        public int idGrupo { get; set; }
        public string estabelecimento { get; set; }
        public virtual empresa empresa { get; set; }
        public virtual grupo_empresa grupo_empresa { get; set; }
        public virtual ICollection<LogExecution> LogExecutions { get; set; }
        public virtual Operadora Operadora { get; set; }
    }
}
