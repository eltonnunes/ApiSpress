using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class estado_usuario
    {
        public estado_usuario()
        {
            this.usuarios = new List<usuario>();
        }

        public string cod_estado { get; set; }
        public string desc_estado { get; set; }
        public virtual ICollection<usuario> usuarios { get; set; }
    }
}
