using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class MSpeer_response
    {
        public Nullable<int> request_id { get; set; }
        public string peer { get; set; }
        public string peer_db { get; set; }
        public Nullable<System.DateTime> received_date { get; set; }
    }
}
