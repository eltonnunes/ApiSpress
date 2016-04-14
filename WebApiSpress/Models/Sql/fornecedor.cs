using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class fornecedor
    {
        public fornecedor()
        {
            this.nfe_entrada = new List<nfe_entrada>();
            this.merca_dePara = new List<merca_dePara>();
            this.nfe_saida = new List<nfe_saida>();
            this.MercaFornecedors = new List<MercaFornecedor>();
        }

        public string nu_cnpjCpf { get; set; }
        public string ds_fantasia { get; set; }
        public string ds_razaoSocial { get; set; }
        public string ds_endereco { get; set; }
        public string sg_uf { get; set; }
        public string nu_cep { get; set; }
        public string nu_telefone { get; set; }
        public string nm_bairro { get; set; }
        public System.DateTime dt_cadastro { get; set; }
        public virtual ICollection<nfe_entrada> nfe_entrada { get; set; }
        public virtual ICollection<merca_dePara> merca_dePara { get; set; }
        public virtual ICollection<nfe_saida> nfe_saida { get; set; }
        public virtual ICollection<MercaFornecedor> MercaFornecedors { get; set; }
    }
}
