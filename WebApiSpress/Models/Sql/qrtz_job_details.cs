using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class qrtz_job_details
    {
        public qrtz_job_details()
        {
            this.qrtz_job_listeners = new List<qrtz_job_listeners>();
            this.qrtz_triggers = new List<qrtz_triggers>();
        }

        public string job_name { get; set; }
        public string job_group { get; set; }
        public string description { get; set; }
        public string job_class_name { get; set; }
        public string is_durable { get; set; }
        public string is_volatile { get; set; }
        public string is_stateful { get; set; }
        public string requests_recovery { get; set; }
        public byte[] job_data { get; set; }
        public virtual ICollection<qrtz_job_listeners> qrtz_job_listeners { get; set; }
        public virtual ICollection<qrtz_triggers> qrtz_triggers { get; set; }
    }
}
