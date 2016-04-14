using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tbEmpresaFilial
    {
        public string nrCNPJ { get; set; }
        public string nrCNPJBase { get; set; }
        public string nrCNPJSequencia { get; set; }
        public string nrCNPJDigito { get; set; }
        public string nmFantasia { get; set; }
        public string nmRazaoSocial { get; set; }
        public string dsEndereco { get; set; }
        public string dsCidade { get; set; }
        public string sgUF { get; set; }
        public string nrCEP { get; set; }
        public string nrTelefone { get; set; }
        public string dsBairro { get; set; }
        public string dsEmail { get; set; }
        public System.DateTime dtCadastro { get; set; }
        public bool flAtivo { get; set; }
        public int cdEmpresaGrupo { get; set; }
        public string nrFilial { get; set; }
        public string nrInscEstadual { get; set; }
        public string token { get; set; }
        public virtual tbEmpresaGrupo tbEmpresaGrupo { get; set; }
    }
}
