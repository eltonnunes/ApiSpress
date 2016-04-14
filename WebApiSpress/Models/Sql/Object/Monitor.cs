using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.Object
{
    
    public class Monitor
    {

    }


    public class LogExecucao
    {
        public int idLogExecucao { get; set; }
        public string empresa { get; set; }
        public int idAdquirente { get; set; }
        public string adquirente { get; set; }
        public string data_carga { get; set; }
        public string data_inicio { get; set; }
        public int? quantidade { get; set; }
        public decimal? valor_total { get; set; }
        public string status { get; set; }
    }

    public class Contador
    {
        public int execucao { get; set; }
        public int fila { get; set; }
        public int erro { get; set; }
        public int sucesso { get; set; }
    }

    public class GrupoEmpresa {
        public string empresa { get; set; }
        public int empresaId { get; set; }
    }

    public class GrupoFilial
    {
        public string filial { get; set; }
        public string cnpj { get; set; }
    }

    public class GrupoAdquirente
    {
        public string adquirente { get; set; }
        public int idAdquirente { get; set; }
    }

    public class NovaCarga
    {
        public int empresa { get; set; }
        public string filial { get; set; }
        public int adquirente { get; set; }
        public string data { get; set; }
        
    }
}