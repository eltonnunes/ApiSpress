using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class nivel_usuarios
    {
        public nivel_usuarios()
        {
            this.usuarios = new List<usuario>();
        }

        public decimal nivel_usuario { get; set; }
        public string desc_nivel_usuario { get; set; }
        public virtual ICollection<usuario> usuarios { get; set; }
    }
}
