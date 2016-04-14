using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class qrtz_cron_triggers
    {
        public string trigger_name { get; set; }
        public string trigger_group { get; set; }
        public string cron_expression { get; set; }
        public string time_zone_id { get; set; }
        public virtual qrtz_triggers qrtz_triggers { get; set; }
    }
}
