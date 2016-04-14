using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class MSpeer_lsns
    {
        public int id { get; set; }
        public Nullable<System.DateTime> last_updated { get; set; }
        public string originator { get; set; }
        public string originator_db { get; set; }
        public string originator_publication { get; set; }
        public Nullable<int> originator_publication_id { get; set; }
        public Nullable<int> originator_db_version { get; set; }
        public byte[] originator_lsn { get; set; }
    }
}
