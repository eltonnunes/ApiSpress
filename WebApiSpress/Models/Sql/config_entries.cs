using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class config_entries
    {
        public string chave { get; set; }
        public string valor { get; set; }
        public int section_id { get; set; }
        public virtual config_section config_section { get; set; }
    }
}
