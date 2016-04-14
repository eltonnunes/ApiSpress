using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiSpress.Models.Firebird
{
    [Table("tb_itens_rc")]
    public partial class tb_itens_rc
    {
        [Key]
        public int cod_item_rc { get; set; }
        public decimal cod_recto { get; set; }
        public int loja { get; set; }
        public string forma { get; set; }
        public DateTime dt_vcto { get; set; }
        public decimal total { get; set; }    
        public int parcela { get; set; }
        public DateTime dt_recebimento { get; set; }
    }
}