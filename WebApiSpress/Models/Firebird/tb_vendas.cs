using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiSpress.Models.Firebird
{
    [Table("tb_vendas")]
    public partial class tb_vendas
    {
        [Key]
        public decimal cod_venda { get; set; }
        public int loja { get; set; }
        public DateTime Dt_Venda { get; set; }
        public decimal Total { get; set; }       
    }
}