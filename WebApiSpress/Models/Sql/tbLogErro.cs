using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tbLogErro
    {
        public int idLogErro { get; set; }
        public string dsAplicacao { get; set; }
        public string dsVersao { get; set; }
        public System.DateTime dtErro { get; set; }
        public string dsNomeComputador { get; set; }
        public string dsNomeUsuario { get; set; }
        public string dsVersaoSO { get; set; }
        public string dsCultura { get; set; }
        public string dsMensagem { get; set; }
        public string dsStackTrace { get; set; }
        public string dsXmlEntrada { get; set; }
    }
}
