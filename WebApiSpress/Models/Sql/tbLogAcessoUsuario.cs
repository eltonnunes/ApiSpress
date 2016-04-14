using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSpress.Models.Sql
{
    public partial class tbLogAcessoUsuario
    {
        public int idLogAcessoUsuario { get; set; }
        public int idUser { get; set; }
        public string dsUrl { get; set; }
        public Nullable<int> idController { get; set; }
        public string dsParametros { get; set; }
        public string dsFiltros { get; set; }
        public System.DateTime dtAcesso { get; set; }
        public string dsAplicacao { get; set; }
        public int codResposta { get; set; }
        public string msgErro { get; set; }
        public string dsJson { get; set; }
        public string dsUserAgent { get; set; }
        public string dsMethod { get; set; }
        public virtual webpages_Users webpages_Users { get; set; }
        public virtual webpages_Controllers webpages_Controllers { get; set; }
    }
}
