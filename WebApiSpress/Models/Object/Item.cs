using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSpress.Models.Object
{
    public class Item
    {
        public int cod_item { get; set; }
        public double qtd_unidade_agrupamento { get; set; }
        public Nullable<int> cod_unidade_agrupamento { get; set; }
        public int cod_unidade {get;set;}
    }
}