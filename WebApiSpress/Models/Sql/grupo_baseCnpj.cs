using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class grupo_baseCnpj
    {
        public string nu_Cnpj { get; set; }
        public string nu_BaseCnpj { get; set; }
        public string nu_SequenciaCnpj { get; set; }
        public string nu_DigitoCnpj { get; set; }
        public string token { get; set; }
        public int id_grupoEmpresa { get; set; }
        public virtual grupo_empresa grupo_empresa { get; set; }
    }
}
