using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class MSpeer_request
    {
        public int id { get; set; }
        public string publication { get; set; }
        public Nullable<System.DateTime> sent_date { get; set; }
        public string description { get; set; }
    }
}
