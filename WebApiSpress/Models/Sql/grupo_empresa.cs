using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class grupo_empresa
    {
        public grupo_empresa()
        {
            this.ConnectionStrings = new List<ConnectionString>();
            this.LogExceptionWinApps = new List<LogExceptionWinApp>();
            this.Bandeiras = new List<Bandeira>();
            this.empresas = new List<empresa>();
            this.grupo_baseCnpj = new List<grupo_baseCnpj>();
            this.ConciliacaoRecebimentoes = new List<ConciliacaoRecebimento>();
            this.mercas = new List<merca>();
            this.merca_dePara = new List<merca_dePara>();
            this.pedidoes = new List<pedido>();
            this.webpages_Users = new List<webpages_Users>();
            this.Bandeiras1 = new List<Bandeira1>();
            this.Operadoras = new List<Operadora>();
            this.LoginOperadoras = new List<LoginOperadora>();
            this.tbContaCorrentes = new List<tbContaCorrente>();
            this.tbLoginAdquirenteEmpresas = new List<tbLoginAdquirenteEmpresa>();
        }

        public int id_grupo { get; set; }
        public string ds_nome { get; set; }
        public System.DateTime dt_cadastro { get; set; }
        public string token { get; set; }
        public bool fl_cardservices { get; set; }
        public bool fl_taxservices { get; set; }
        public bool fl_proinfo { get; set; }
        public Nullable<int> id_vendedor { get; set; }
        public bool fl_ativo { get; set; }
        public virtual ICollection<ConnectionString> ConnectionStrings { get; set; }
        public virtual ICollection<LogExceptionWinApp> LogExceptionWinApps { get; set; }
        public virtual ICollection<Bandeira> Bandeiras { get; set; }
        public virtual ICollection<empresa> empresas { get; set; }
        public virtual ICollection<grupo_baseCnpj> grupo_baseCnpj { get; set; }
        public virtual ICollection<ConciliacaoRecebimento> ConciliacaoRecebimentoes { get; set; }
        public virtual ICollection<merca> mercas { get; set; }
        public virtual ICollection<merca_dePara> merca_dePara { get; set; }
        public virtual ICollection<pedido> pedidoes { get; set; }
        public virtual ICollection<webpages_Users> webpages_Users { get; set; }
        public virtual ICollection<Bandeira1> Bandeiras1 { get; set; }
        public virtual ICollection<Operadora> Operadoras { get; set; }
        public virtual ICollection<LoginOperadora> LoginOperadoras { get; set; }
        public virtual webpages_Users Vendedor { get; set; }
        public virtual ICollection<tbContaCorrente> tbContaCorrentes { get; set; }
        public virtual ICollection<tbLoginAdquirenteEmpresa> tbLoginAdquirenteEmpresas { get; set; }
    }
}
