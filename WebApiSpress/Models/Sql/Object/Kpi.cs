using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.Object
{
    public class Kpi
    {
    }

    public class KpiGrupo
    {
        public int IdGrupo { get; set; }
        public string Nome { get; set; }
        public int Status { get; set; }
        public string DtUltimoAcesso { get; set; }
        public string DtCadastro { get; set; }
    }

    public class Empresa
    {
        public int empresaId { get; set; }
        public string empresa { get; set; }
        public string data_cadastro { get; set; }
        public string data_ultimo_acesso { get; set; }
        public int status { get; set; }
        public List<Filial> filiais { get; set; }
    }        


    public class Filial
    {
        public string cnpj { get; set; }
        public string filial { get; set; }
        public int status { get; set; }
        public List<Adquirente> adquirentes { get; set; }
    }

    public class Adquirente
    {
        public string nome { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public string estabelecimento { get; set; }
        public int status { get; set; }
        public string data_ultima_carga { get; set; }
        public Int32? qtd_transacoes { get; set; }
        public decimal? montante { get; set; }
    }
}