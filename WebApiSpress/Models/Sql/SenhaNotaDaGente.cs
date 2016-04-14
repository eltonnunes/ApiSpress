using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class SenhaNotaDaGente
    {
        public long id_SenhaNotaDaGente { get; set; }
        public string ds_password { get; set; }
        public Nullable<System.DateTime> dt_alteracao { get; set; }
        public Nullable<System.DateTime> dt_situacao { get; set; }
        public Nullable<byte> fl_status { get; set; }
        public string nu_cnpj { get; set; }
    }
}
