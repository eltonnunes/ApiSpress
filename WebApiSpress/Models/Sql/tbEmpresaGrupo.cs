using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tbEmpresaGrupo
    {
        public tbEmpresaGrupo()
        {
            this.tbEmpresas = new List<tbEmpresa>();
            this.tbEmpresaFiliais = new List<tbEmpresaFilial>();
        }

        public int cdEmpresaGrupo { get; set; }
        public string dsEmpresaGrupo { get; set; }
        public System.DateTime dtCadastro { get; set; }
        public bool flCardServices { get; set; }
        public bool flTaxServices { get; set; }
        public bool flProinfo { get; set; }
        public Nullable<int> cdVendedor { get; set; }
        public bool flAtivo { get; set; }
        public virtual ICollection<tbEmpresa> tbEmpresas { get; set; }
        public virtual ICollection<tbEmpresaFilial> tbEmpresaFiliais { get; set; }
    }
}
