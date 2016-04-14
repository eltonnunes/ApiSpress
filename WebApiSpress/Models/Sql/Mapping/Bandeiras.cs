using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiSpress.Models.Sql.Mapping
{
    [Table("Bandeiras", Schema = "cartao")]
    public partial class Bandeiras
    {
        [Key]
        public int IdBandeira { get; set; }
        public string DescricaoBandeira { get; set; }
        public Nullable<int> IdGrupo { get; set; }
        public string CodBandeiraERP { get; set; }
        public decimal CodBandeiraHostPagamento { get; set; }
        public decimal TaxaAdministracao { get; set; }
        public int IdTipoPagamento { get; set; }
        public string Sacado { get; set; }
    }
}