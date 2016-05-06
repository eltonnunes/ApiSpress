using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSpress.Models.Object
{
    public class ParcelaSpress
    {
        public string K0;
        public int PARNRO;
        public decimal PARVLR;
        public int PARDATVENCTO;

        public ParcelaSpress()
        {
            this.K0 = String.Empty;
            this.PARNRO = 0;
            this.PARVLR = new decimal(0.0);
            this.PARDATVENCTO = 0;
        }
    }
}