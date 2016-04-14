using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.Object
{
    public class Login
    {
        public string usuario { get; set; }
        public string senha { get; set; }
    }

    public class Autenticado
    {
        public string nome { get; set; }
        public string usuario { get; set; }
        public string token { get; set; }
        public Int32 id_grupo { get; set; }
        public string nu_cnpj { get; set; }
        public Boolean filtro_empresa { get; set; }
        public List<dynamic> controllers { get; set; }
    }


    public class Controllers 
    {
        public int id_controller { get; set; }
        public string ds_controller { get; set; }
        public List<dynamic> subControllers { get; set; }
        public Boolean home { get; set; }
    }



}