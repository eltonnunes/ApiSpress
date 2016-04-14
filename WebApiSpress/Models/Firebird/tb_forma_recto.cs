using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApiSpress.Models.Firebird
{
    [Table("tb_forma_recto")]
    public partial class tb_forma_recto
    {
        [Key]
        public int COD_FORMA_RECTO { get; set; }
        public int loja { get; set; }
        public int pagamento { get; set; }
        public string PGTO_FANTASIA { get; set; }
    }
}