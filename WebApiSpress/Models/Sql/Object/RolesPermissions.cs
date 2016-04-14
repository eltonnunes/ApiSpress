using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.Object
{
    public class RolesPermissions
    {
        private Int32 id_roles;
        public Int32 Id_roles
        {
            get { return id_roles; }
            set { id_roles = value; }
        }

        private Int32 id_controller_principal;
        public Int32 Id_controller_principal
        {
            get { return id_controller_principal; }
            set { id_controller_principal = value; }
        }

        private List<Int32> inserir;
        public List<Int32> Inserir
        {
            get { return inserir; }
            set { inserir = value; }
        }

        private List<Int32> deletar;
        public List<Int32> Deletar
        {
            get { return deletar; }
            set { deletar = value; }
        }
    }
}