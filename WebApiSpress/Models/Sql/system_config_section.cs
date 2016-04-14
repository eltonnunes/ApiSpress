using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class system_config_section
    {
        public system_config_section()
        {
            this.system_config_entries = new List<system_config_entries>();
        }

        public int id { get; set; }
        public string nome { get; set; }
        public string aplicacao { get; set; }
        public decimal se_cliente { get; set; }
        public decimal id_schema { get; set; }
        public virtual ICollection<system_config_entries> system_config_entries { get; set; }
    }
}
