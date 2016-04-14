using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSpress.Models.Sql
{
    public partial class webpages_Controllers
    {
        public webpages_Controllers()
        {
            this.LogAcesso1 = new List<LogAcesso1>();
            this.webpages_Methods = new List<webpages_Methods>();
            this.webpages_Controllers1 = new List<webpages_Controllers>();
            this.tbLogAcessoUsuarios = new List<tbLogAcessoUsuario>();
        }

        public int id_controller { get; set; }
        public string ds_controller { get; set; }
        public string nm_controller { get; set; }
        public bool fl_menu { get; set; }
        public Nullable<int> id_subController { get; set; }
        public int nuOrdem { get; set; }
        public virtual ICollection<LogAcesso1> LogAcesso1 { get; set; }
        public virtual ICollection<webpages_Methods> webpages_Methods { get; set; }
        public virtual ICollection<webpages_Controllers> webpages_Controllers1 { get; set; }
        public virtual webpages_Controllers webpages_Controllers2 { get; set; }
        public virtual ICollection<tbLogAcessoUsuario> tbLogAcessoUsuarios { get; set; }
    }
}
