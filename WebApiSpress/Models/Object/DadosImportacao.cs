using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSpress.Models.Object
{
    public class DadosImportacao
    {
        public string nrChave { get; set; }
        public int codAlmoxarifado { get; set; }
        public int codNaturezaOperacao { get; set; }
        public DateTime dtEntrega { get; set; }
    }
}