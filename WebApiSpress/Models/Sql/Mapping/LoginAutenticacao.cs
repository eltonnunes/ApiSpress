using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiSpress.Models.Sql.Mapping
{
    [Table("LoginAutenticacao", Schema = "moblie")]
    public class LoginAutenticacao
    {
        [Key]
        public int idUsers { get; set; }
        public string token { get; set; }
        public Nullable<System.DateTime> dtValidade { get; set; }
        //public virtual webpages_Users webpages_Users { get; set; }
    }
}