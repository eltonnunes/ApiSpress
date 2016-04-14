using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class syssubscription
    {
        public int artid { get; set; }
        public short srvid { get; set; }
        public string dest_db { get; set; }
        public byte status { get; set; }
        public byte sync_type { get; set; }
        public string login_name { get; set; }
        public int subscription_type { get; set; }
        public byte[] distribution_jobid { get; set; }
        public byte[] timestamp { get; set; }
        public byte update_mode { get; set; }
        public bool loopback_detection { get; set; }
        public bool queued_reinit { get; set; }
        public byte nosync_type { get; set; }
        public string srvname { get; set; }
    }
}
