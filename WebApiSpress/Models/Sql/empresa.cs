using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class empresa
    {
        public empresa()
        {
            this.Cargas = new List<Carga>();
            this.PDVs = new List<PDV>();
            this.nfe_entrada = new List<nfe_entrada>();
            this.nfe_saida = new List<nfe_saida>();
            this.pedidoes = new List<pedido>();
            this.Recebimentoes = new List<Recebimento>();
            this.webpages_Users = new List<webpages_Users>();
            this.Cieloes = new List<Cielo>();
            this.Amexes = new List<Amex>();
            this.BaneseCards = new List<BaneseCard>();
            this.FitCards = new List<FitCard>();
            this.GetNetSantanders = new List<GetNetSantander>();
            this.GoodCards = new List<GoodCard>();
            this.GreenCards = new List<GreenCard>();
            this.Nutricashes = new List<Nutricash>();
            this.Omnis = new List<Omni>();
            this.PoliCards = new List<PoliCard>();
            this.RedeCards = new List<RedeCard>();
            this.RedeMeds = new List<RedeMed>();
            this.Sodexoes = new List<Sodexo>();
            this.TicketCars = new List<TicketCar>();
            this.ValeCards = new List<ValeCard>();
            this.LoginOperadoras = new List<LoginOperadora>();
            this.ConciliacaoPagamentosPos = new List<ConciliacaoPagamentosPos>();
            this.TaxaAdministracaos = new List<TaxaAdministracao>();
            this.tbContaCorrentes = new List<tbContaCorrente>();
            this.tbLoginAdquirenteEmpresas = new List<tbLoginAdquirenteEmpresa>();
            this.tbBancoParametros = new List<tbBancoParametro>();
            this.tbRecebimentoTituloes = new List<tbRecebimentoTitulo>();
        }

        public string nu_cnpj { get; set; }
        public string nu_BaseCnpj { get; set; }
        public string nu_SequenciaCnpj { get; set; }
        public string nu_DigitoCnpj { get; set; }
        public string ds_fantasia { get; set; }
        public string ds_razaoSocial { get; set; }
        public string ds_endereco { get; set; }
        public string ds_cidade { get; set; }
        public string sg_uf { get; set; }
        public string nu_cep { get; set; }
        public string nu_telefone { get; set; }
        public string ds_bairro { get; set; }
        public string ds_email { get; set; }
        public System.DateTime dt_cadastro { get; set; }
        public long fl_ativo { get; set; }
        public string token { get; set; }
        public int id_grupo { get; set; }
        public string filial { get; set; }
        public Nullable<long> nu_inscEstadual { get; set; }
        public virtual ICollection<Carga> Cargas { get; set; }
        public virtual ICollection<PDV> PDVs { get; set; }
        public virtual grupo_empresa grupo_empresa { get; set; }
        public virtual ICollection<nfe_entrada> nfe_entrada { get; set; }
        public virtual ICollection<nfe_saida> nfe_saida { get; set; }
        public virtual ICollection<pedido> pedidoes { get; set; }
        public virtual ICollection<Recebimento> Recebimentoes { get; set; }
        public virtual ICollection<webpages_Users> webpages_Users { get; set; }
        public virtual ICollection<Cielo> Cieloes { get; set; }
        public virtual ICollection<Amex> Amexes { get; set; }
        public virtual ICollection<BaneseCard> BaneseCards { get; set; }
        public virtual ICollection<FitCard> FitCards { get; set; }
        public virtual ICollection<GetNetSantander> GetNetSantanders { get; set; }
        public virtual ICollection<GoodCard> GoodCards { get; set; }
        public virtual ICollection<GreenCard> GreenCards { get; set; }
        public virtual ICollection<Nutricash> Nutricashes { get; set; }
        public virtual ICollection<Omni> Omnis { get; set; }
        public virtual ICollection<PoliCard> PoliCards { get; set; }
        public virtual ICollection<RedeCard> RedeCards { get; set; }
        public virtual ICollection<RedeMed> RedeMeds { get; set; }
        public virtual ICollection<Sodexo> Sodexoes { get; set; }
        public virtual ICollection<TicketCar> TicketCars { get; set; }
        public virtual ICollection<ValeCard> ValeCards { get; set; }
        public virtual ICollection<LoginOperadora> LoginOperadoras { get; set; }
        public virtual ICollection<ConciliacaoPagamentosPos> ConciliacaoPagamentosPos { get; set; }
        public virtual ICollection<TaxaAdministracao> TaxaAdministracaos { get; set; }
        public virtual ICollection<tbContaCorrente> tbContaCorrentes { get; set; }
        public virtual ICollection<tbLoginAdquirenteEmpresa> tbLoginAdquirenteEmpresas { get; set; }
        public virtual ICollection<tbBancoParametro> tbBancoParametros { get; set; }
        //public virtual ICollection<tbRecebimento> tbRecebimentos { get; set; }
        public virtual ICollection<tbRecebimentoTitulo> tbRecebimentoTituloes { get; set; }
    }
}
