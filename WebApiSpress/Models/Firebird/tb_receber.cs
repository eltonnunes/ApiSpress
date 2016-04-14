using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiSpress.Models.Firebird
{
    [Table("tb_receber")]
    public partial class tb_receber
    {
        [Key]
        public decimal cod_recto { get; set; }
        public int loja { get; set; }
        public int Parcelas { get; set; }        
    }
}
