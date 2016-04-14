using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.Object
{
    public class Usuario
    {
        private pessoa pessoa;
        public pessoa Pessoa
        {
            get { return pessoa; }
            set { pessoa = value; }
        }

        private webpages_Users webpagesusers;

        public webpages_Users Webpagesusers
        {
            get { return webpagesusers; }
            set { webpagesusers = value; }
        }

        private List<webpages_UsersInRoles> webpagesusersinroles;

        public List<webpages_UsersInRoles> Webpagesusersinroles
        {
            get { return webpagesusersinroles; }
            set { webpagesusersinroles = value; }
        }

        private Int32 id_grupo;
        public Int32 Id_grupo
        {
            get { return id_grupo; }
            set { id_grupo = value; }
        }

        private List<Int32> addidsgrupoempresavendedor;
        public List<Int32> Addidsgrupoempresavendedor
        {
            get { return addidsgrupoempresavendedor; }
            set { addidsgrupoempresavendedor = value; }
        }

        private List<Int32> removeidsgrupoempresavendedor;
        public List<Int32> Removeidsgrupoempresavendedor
        {
            get { return removeidsgrupoempresavendedor; }
            set { removeidsgrupoempresavendedor = value; }
        }

    }

}