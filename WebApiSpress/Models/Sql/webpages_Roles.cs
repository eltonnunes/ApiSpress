using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class webpages_Roles
    {
        public webpages_Roles()
        {
            this.webpages_Permissions = new List<webpages_Permissions>();
            this.webpages_Membership = new List<webpages_Membership>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int RoleLevel { get; set; }
        public virtual ICollection<webpages_Permissions> webpages_Permissions { get; set; }
        public virtual ICollection<webpages_Membership> webpages_Membership { get; set; }
        public virtual webpages_RoleLevels webpages_RoleLevels { get; set; }
        public virtual ICollection<webpages_UsersInRoles> webpages_UsersInRoles { get; set; }
    }
}
