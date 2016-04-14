using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class config_section
    {
        public config_section()
        {
            this.config_entries = new List<config_entries>();
        }

        public int id { get; set; }
        public string nome { get; set; }
        public string aplicacao { get; set; }
        public decimal se_cliente { get; set; }
        public decimal id_schema { get; set; }
        public virtual ICollection<config_entries> config_entries { get; set; }
    }
}
