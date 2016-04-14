using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class historico_senhas
    {
        public string cod_usuario { get; set; }
        public string senha { get; set; }
        public Nullable<System.DateTime> cadastro { get; set; }
        public decimal contador { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
