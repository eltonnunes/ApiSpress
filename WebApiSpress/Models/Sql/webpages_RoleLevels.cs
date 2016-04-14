using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSpress.Models.Sql
{
    public class webpages_RoleLevels
    {
        public webpages_RoleLevels()
        {
            this.webpages_Roles = new List<webpages_Roles>();
        }

        public int LevelId { get; set; }
        public string LevelName { get; set; }
        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }
    }
}