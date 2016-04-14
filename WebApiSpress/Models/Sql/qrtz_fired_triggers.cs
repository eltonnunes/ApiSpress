using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class qrtz_fired_triggers
    {
        public string entry_id { get; set; }
        public string trigger_name { get; set; }
        public string trigger_group { get; set; }
        public string is_volatile { get; set; }
        public string instance_name { get; set; }
        public decimal fired_time { get; set; }
        public decimal priority { get; set; }
        public string state { get; set; }
        public string job_name { get; set; }
        public string job_group { get; set; }
        public string is_stateful { get; set; }
        public string requests_recovery { get; set; }
    }
}
