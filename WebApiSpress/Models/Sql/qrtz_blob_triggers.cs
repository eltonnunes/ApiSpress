using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class qrtz_blob_triggers
    {
        public string trigger_name { get; set; }
        public string trigger_group { get; set; }
        public byte[] blob_data { get; set; }
        public virtual qrtz_triggers qrtz_triggers { get; set; }
    }
}
