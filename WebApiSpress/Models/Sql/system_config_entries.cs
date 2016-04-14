using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class system_config_entries
    {
        public string chave { get; set; }
        public string valor { get; set; }
        public int section_id { get; set; }
        public virtual system_config_section system_config_section { get; set; }
    }
}
