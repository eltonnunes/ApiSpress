using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class DATABASECHANGELOGLOCK
    {
        public int ID { get; set; }
        public bool LOCKED { get; set; }
        public Nullable<System.DateTime> LOCKGRANTED { get; set; }
        public string LOCKEDBY { get; set; }
    }
}
