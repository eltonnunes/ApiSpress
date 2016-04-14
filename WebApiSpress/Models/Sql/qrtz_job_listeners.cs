using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class qrtz_job_listeners
    {
        public string job_name { get; set; }
        public string job_group { get; set; }
        public string job_listener { get; set; }
        public virtual qrtz_job_details qrtz_job_details { get; set; }
    }
}
