using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.Object
{
    public class Log
    {
        public int IdUser { get; set; }
        public int IdController { get; set; }
        public int IdMethod { get; set; }
        public DateTime DtAcesso { get; set; }
    }
}