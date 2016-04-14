using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class qrtz_simple_triggers
    {
        public string trigger_name { get; set; }
        public string trigger_group { get; set; }
        public decimal repeat_count { get; set; }
        public decimal repeat_interval { get; set; }
        public decimal times_triggered { get; set; }
        public virtual qrtz_triggers qrtz_triggers { get; set; }
    }
}
