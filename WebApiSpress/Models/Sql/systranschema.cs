using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class systranschema
    {
        public int tabid { get; set; }
        public byte[] startlsn { get; set; }
        public byte[] endlsn { get; set; }
        public int typeid { get; set; }
    }
}
