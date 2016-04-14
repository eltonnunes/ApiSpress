using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSpress.Models.Object
{
    public class ICMSIPI
    {
        public int cod_tributacao_ipi { get; set; }
        public int cod_tributacao_icms { get; set; }
        public int cod_natureza_operacao { get; set; }
        public double val_ipi { get; set; }
        public double val_base_ipi { get; set; }
        public double val_base_icms { get; set; }
        public double val_icms { get; set; }
        public double per_aliquota_icms { get; set; }
        public double val_icms_outros { get; set; }
        public double val_icms_nao_tributado { get; set; }
        public double val_base_icms_bruto { get; set; }
        public double val_base_icms_substituicao { get; set; }
        public double val_icms_substituicao { get; set; }
        public double per_aliquota_icms_st { get; set; }
        public double val_icms_isento { get; set; }
        public double per_aliquota_ipi { get; set; }

    }
}