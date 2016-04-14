using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiSpress.Models.Firebird
{
    [Table("tb_loja")]
    public partial class tb_loja
    {
        [Key]
        public int cod_loja { get; set; }
        public int loja { get; set; }
        public int CNPJ { get; set; }        
    }
}
