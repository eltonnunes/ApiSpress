using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class webpages_Methods
    {
        public webpages_Methods()
        {
            this.LogAcesso1 = new List<LogAcesso1>();
            this.webpages_Permissions = new List<webpages_Permissions>();
        }

        public int id_method { get; set; }
        public string ds_method { get; set; }
        public string nm_method { get; set; }
        public bool fl_menu { get; set; }
        public int id_controller { get; set; }
        public virtual webpages_Controllers webpages_Controllers { get; set; }
        public virtual ICollection<LogAcesso1> LogAcesso1 { get; set; }
        public virtual ICollection<webpages_Permissions> webpages_Permissions { get; set; }
    }
}
