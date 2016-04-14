
using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tbAdquirente
    {
        public tbAdquirente()
        {
            this.tbBancoParametroes = new List<tbBancoParametro>();
            this.tbLoginAdquirenteEmpresas = new List<tbLoginAdquirenteEmpresa>();
            this.tbRecebimentoTituloes = new List<tbRecebimentoTitulo>();
        }

        public int cdAdquirente { get; set; }
        public string nmAdquirente { get; set; }
        public string dsAdquirente { get; set; }
        public byte stAdquirente { get; set; }
        public System.DateTime hrExecucao { get; set; }
        public virtual ICollection<tbBancoParametro> tbBancoParametroes { get; set; }
        public virtual ICollection<tbLoginAdquirenteEmpresa> tbLoginAdquirenteEmpresas { get; set; }
        public virtual ICollection<tbRecebimentoTitulo> tbRecebimentoTituloes { get; set; }
    }
}
