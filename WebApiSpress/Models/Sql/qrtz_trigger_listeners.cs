using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class qrtz_trigger_listeners
    {
        public string trigger_name { get; set; }
        public string trigger_group { get; set; }
        public string trigger_listener { get; set; }
        public virtual qrtz_triggers qrtz_triggers { get; set; }
    }
}
