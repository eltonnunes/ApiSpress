using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.Object
{
    public class Modulo
    {
        public string Nome { get; set; }
        public string Namespace { get; set; }
        public bool FlagMenu { get; set; }
    }

    public class Controller
    {
        public string Nome { get; set; }
        public string Namespace { get; set; }
        public int IdModulo { get; set; }
        public bool FlagMenu { get; set; }
    }

    public class Method
    {
        public string Nome { get; set; }
        public string Namespace { get; set; }
        public int IdController { get; set; }
        public bool FlagMenu { get; set; }
    }
}