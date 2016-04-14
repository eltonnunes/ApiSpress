using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tbSituacaoRedeTef
    {
        public short cdSituacaoRedeTef { get; set; }
        public Nullable<short> cdRedeTef { get; set; }
        public string dsSituacao { get; set; }
        public Nullable<short> cdTipoSituacao { get; set; }
    }
}
