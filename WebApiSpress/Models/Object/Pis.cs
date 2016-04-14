using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSpress.Models.Object
{
    public class Pis
    {
        public double per_credito_pis { get; set; }
        public double per_aliquota_pis { get; set; }
        public double val_pis_recuperar { get; set; }
        public int cod_tributacao_pis { get; set; }
        public double val_pis { get; set; }
        public double val_base_pis { get; set; }
    }
}