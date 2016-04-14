using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models.Object
{
    public class ControllersOrigem
    {
        private Int32 idController;
        public Int32 IdController
        {
            get { return idController; }
            set { idController = value; }
        }

        private string[] metodos;
        public string[] Metodos
        {
            get { return metodos; }
            set { metodos = value; }
        }

        public ControllersOrigem()
        {
            idController = 0;
            metodos = new string[0];
        }

        public ControllersOrigem(Int32 idController, string[] metodos)
        {
            this.idController = idController;
            this.metodos = new string[metodos.Length];
            metodos.CopyTo(this.metodos, 0);
        }
    }

    public class AcessoMetodoAPI
    {
        private Dictionary<string, List<ControllersOrigem>> acesso;

        public AcessoMetodoAPI()
        {
            acesso = new Dictionary<string, List<ControllersOrigem>>();
        }

        public int Count()
        {
            return acesso.Count;
        } 

        public void Clear()
        {
            acesso.Clear();
        }

        public bool Add(string url, List<ControllersOrigem> controllers)
        {
            try
            {
                // Copia cada elemento
                List<ControllersOrigem> list = new List<ControllersOrigem>(controllers);
                acesso.Add(url, list);
                return true;
            }
            catch { return false;  }
        }

        public List<ControllersOrigem> GetControllersOrigem(string url)
        {
            return acesso.Where(e => e.Key.Equals(url)).Select(e => e.Value).FirstOrDefault();
        }

        public bool IsControllerPermitidoInURL(string url, Int32 idController)
        {
            List<ControllersOrigem> controllersOrigem = GetControllersOrigem(url);
            if (controllersOrigem == null) return false;
            return controllersOrigem.Where(e => e.IdController == idController).FirstOrDefault() != null;
        }

        public bool IsMetodoControllerPermitidoInURL(string url, Int32 idController, string metodo)
        {
            List<ControllersOrigem> controllersOrigem = GetControllersOrigem(url);
            if (controllersOrigem == null) return false;
            metodo = metodo.ToUpper();
            ControllersOrigem controllerOrigem = controllersOrigem.Where(e => e.IdController == idController).FirstOrDefault();
            if (controllerOrigem == null) return false;
            return controllerOrigem.Metodos.Where(e => e.ToUpper().Equals(metodo)).FirstOrDefault() != null;

        }
    }
}
