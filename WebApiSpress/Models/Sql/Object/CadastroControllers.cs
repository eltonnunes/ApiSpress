using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.Object
{
    public class CadastroController
    {
        private webpages_Controllers webpagescontrollers;
        public webpages_Controllers Webpagescontrollers
        {
          get { return webpagescontrollers; }
          set { webpagescontrollers = value; }
        }

        private Boolean methodspadrao;
        public Boolean Methodspadrao
        {
            get { return methodspadrao; }
            set { methodspadrao = value; }
        }
    }
}