using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class columnmodel
    {
        public string module { get; set; }
        public string submodule { get; set; }
        public string name { get; set; }
        public byte[] model { get; set; }
        public string versao { get; set; }
    }
}
