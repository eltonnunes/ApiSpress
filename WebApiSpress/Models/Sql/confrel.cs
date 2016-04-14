using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class confrel
    {
        public string cod_usuario { get; set; }
        public string logrede { get; set; }
        public string colunalog { get; set; }
        public string descricao { get; set; }
        public decimal ordem { get; set; }
        public decimal formato { get; set; }
        public decimal tamcoluna { get; set; }
    }
}
