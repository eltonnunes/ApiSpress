using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class Operadora
    {
        public Operadora()
        {
            this.Amexes = new List<Amex>();
            this.BandeiraPos = new List<BandeiraPos>();
            this.BaneseCards = new List<BaneseCard>();
            this.Cieloes = new List<Cielo>();
            this.ConciliacaoPagamentosPos = new List<ConciliacaoPagamentosPos>();
            this.FitCards = new List<FitCard>();
            this.GetNetSantanders = new List<GetNetSantander>();
            this.GoodCards = new List<GoodCard>();
            this.GreenCards = new List<GreenCard>();
            this.LoginOperadoras = new List<LoginOperadora>();
            this.Nutricashes = new List<Nutricash>();
            this.Omnis = new List<Omni>();
            this.PoliCards = new List<PoliCard>();
            this.RedeCards = new List<RedeCard>();
            this.RedeMeds = new List<RedeMed>();
            this.Sodexoes = new List<Sodexo>();
            this.TerminalLogicoes = new List<TerminalLogico>();
            this.TicketCars = new List<TicketCar>();
            this.ValeCards = new List<ValeCard>();
        }

        public int id { get; set; }
        public string nmOperadora { get; set; }
        public int idGrupoEmpresa { get; set; }
        public virtual grupo_empresa grupo_empresa { get; set; }
        public virtual ICollection<Amex> Amexes { get; set; }
        public virtual ICollection<BandeiraPos> BandeiraPos { get; set; }
        public virtual ICollection<BaneseCard> BaneseCards { get; set; }
        public virtual ICollection<Cielo> Cieloes { get; set; }
        public virtual ICollection<ConciliacaoPagamentosPos> ConciliacaoPagamentosPos { get; set; }
        public virtual ICollection<FitCard> FitCards { get; set; }
        public virtual ICollection<GetNetSantander> GetNetSantanders { get; set; }
        public virtual ICollection<GoodCard> GoodCards { get; set; }
        public virtual ICollection<GreenCard> GreenCards { get; set; }
        public virtual ICollection<LoginOperadora> LoginOperadoras { get; set; }
        public virtual ICollection<Nutricash> Nutricashes { get; set; }
        public virtual ICollection<Omni> Omnis { get; set; }
        public virtual ICollection<PoliCard> PoliCards { get; set; }
        public virtual ICollection<RedeCard> RedeCards { get; set; }
        public virtual ICollection<RedeMed> RedeMeds { get; set; }
        public virtual ICollection<Sodexo> Sodexoes { get; set; }
        public virtual ICollection<TerminalLogico> TerminalLogicoes { get; set; }
        public virtual ICollection<TicketCar> TicketCars { get; set; }
        public virtual ICollection<ValeCard> ValeCards { get; set; }
    }
}
