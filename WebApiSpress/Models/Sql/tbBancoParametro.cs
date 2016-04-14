using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSpress.Models.Sql
{
    public partial class tbBancoParametro
    { 
        public string cdBanco { get; set; }
        public string dsMemo { get; set; }
        public Nullable<int> cdAdquirente { get; set; }
        public string dsTipo { get; set; }
        public bool flVisivel { get; set; }
        public string nrCnpj { get; set; }
        public virtual tbAdquirente tbAdquirente { get; set; }
        public virtual empresa empresa { get; set; }
    }
}
