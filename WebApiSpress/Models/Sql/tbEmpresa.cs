using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tbEmpresa
    {
        public string nrCNPJBase { get; set; }
        public byte[] dsCertificadoDigital { get; set; }
        public string dsCertificadoDigitalSenha { get; set; }
        public int cdEmpresaGrupo { get; set; }
        public Nullable<System.DateTime> dtCadastro { get; set; }
        public Nullable<System.DateTime> dtValidade { get; set; }
        public Nullable<bool> flSenhaValida { get; set; }
        public virtual tbEmpresaGrupo tbEmpresaGrupo { get; set; }

    }
}
