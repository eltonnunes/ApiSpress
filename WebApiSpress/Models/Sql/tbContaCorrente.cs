
using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tbContaCorrente
    {
        public tbContaCorrente()
        {
            this.tbContaCorrente_tbLoginAdquirenteEmpresas = new List<tbContaCorrente_tbLoginAdquirenteEmpresa>();
            this.tbExtratos = new List<tbExtrato>();
        }

        public int cdContaCorrente { get; set; }
        public int cdGrupo { get; set; }
        public string nrCnpj { get; set; }
        public string cdBanco { get; set; }
        public string nrAgencia { get; set; }
        public string nrConta { get; set; }
        public bool flAtivo { get; set; }
        public virtual ICollection<tbContaCorrente_tbLoginAdquirenteEmpresa> tbContaCorrente_tbLoginAdquirenteEmpresas { get; set; }
        public virtual ICollection<tbExtrato> tbExtratos { get; set; }
        public virtual empresa empresa { get; set; }
        public virtual grupo_empresa grupo_empresa { get; set; }
    }
}