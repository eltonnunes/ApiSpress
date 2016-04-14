using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class qrtz_triggers
    {
        public qrtz_triggers()
        {
            this.qrtz_trigger_listeners = new List<qrtz_trigger_listeners>();
        }

        public string trigger_name { get; set; }
        public string trigger_group { get; set; }
        public string job_name { get; set; }
        public string job_group { get; set; }
        public string is_volatile { get; set; }
        public string description { get; set; }
        public Nullable<decimal> next_fire_time { get; set; }
        public Nullable<decimal> prev_fire_time { get; set; }
        public Nullable<decimal> priority { get; set; }
        public string trigger_state { get; set; }
        public string trigger_type { get; set; }
        public decimal start_time { get; set; }
        public Nullable<decimal> end_time { get; set; }
        public string calendar_name { get; set; }
        public Nullable<decimal> misfire_instr { get; set; }
        public byte[] job_data { get; set; }
        public virtual qrtz_blob_triggers qrtz_blob_triggers { get; set; }
        public virtual qrtz_cron_triggers qrtz_cron_triggers { get; set; }
        public virtual qrtz_job_details qrtz_job_details { get; set; }
        public virtual qrtz_simple_triggers qrtz_simple_triggers { get; set; }
        public virtual ICollection<qrtz_trigger_listeners> qrtz_trigger_listeners { get; set; }
    }
}
