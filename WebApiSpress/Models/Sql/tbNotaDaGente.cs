using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tbNotaDaGente
    {
        public short cdLoja { get; set; }
        public short nrPDV { get; set; }
        public System.DateTime dtMovimento { get; set; }
        public byte tpStatus { get; set; }
        public long nrProtocolo { get; set; }
        public string dsObservacao { get; set; }
        public Nullable<System.DateTime> dtEnvio { get; set; }
        public string dsArquivo { get; set; }
    }
}
