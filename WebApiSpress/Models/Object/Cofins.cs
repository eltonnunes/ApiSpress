using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSpress.Models.Object
{
    public class Cofins
    {
        public double per_credito_cofins { get; set; }
        public double per_aliquota_cofins { get; set; }
        public double val_cofins_recuperar { get; set; }
        public int cod_tributacao_cofins { get; set; }
        public double val_cofins { get; set; }
        public double val_base_cofins { get; set; }
    }
}