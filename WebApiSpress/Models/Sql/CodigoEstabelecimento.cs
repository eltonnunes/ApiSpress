using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class CodigoEstabelecimento
    {
        public decimal cod_Empresa { get; set; }
        public Nullable<decimal> cod_RedeCard { get; set; }
        public Nullable<decimal> cod_Visanet { get; set; }
        public Nullable<decimal> cod_TecBan { get; set; }
        public Nullable<decimal> cod_Amex { get; set; }
        public Nullable<decimal> cod_Banese { get; set; }
        public Nullable<decimal> cod_Nutricash { get; set; }
        public Nullable<decimal> cod_RedeBase { get; set; }
        public Nullable<decimal> cod_Ecapture { get; set; }
        public Nullable<decimal> cod_Sodexo { get; set; }
        public Nullable<decimal> cod_VRSmart { get; set; }
        public Nullable<decimal> cod_Ticket { get; set; }
    }
}
