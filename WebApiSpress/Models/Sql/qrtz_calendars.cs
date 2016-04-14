using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class qrtz_calendars
    {
        public string calendar_name { get; set; }
        public byte[] calendar { get; set; }
    }
}
