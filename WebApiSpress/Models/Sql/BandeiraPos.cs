using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class BandeiraPos
    {
        public BandeiraPos()
        {
            this.Amexes = new List<Amex>();
            this.BaneseCards = new List<BaneseCard>();
            this.Cieloes = new List<Cielo>();
            this.FitCards = new List<FitCard>();
            this.GetNetSantanders = new List<GetNetSantander>();
            this.GoodCards = new List<GoodCard>();
            this.GreenCards = new List<GreenCard>();
            this.Nutricashes = new List<Nutricash>();
            this.Omnis = new List<Omni>();
            this.PoliCards = new List<PoliCard>();
            this.Recebimentoes = new List<Recebimento>();
            this.RedeCards = new List<RedeCard>();
            this.RedeMeds = new List<RedeMed>();
            this.Sodexoes = new List<Sodexo>();
            this.TaxaAdministracaos = new List<TaxaAdministracao>();
            this.TicketCars = new List<TicketCar>();
            this.ValeCards = new List<ValeCard>();
        }

        public int id { get; set; }
        public string desBandeira { get; set; }
        public int idOperadora { get; set; }
        public virtual ICollection<Amex> Amexes { get; set; }
        public virtual Operadora Operadora { get; set; }
        public virtual ICollection<BaneseCard> BaneseCards { get; set; }
        public virtual ICollection<Cielo> Cieloes { get; set; }
        public virtual ICollection<FitCard> FitCards { get; set; }
        public virtual ICollection<GetNetSantander> GetNetSantanders { get; set; }
        public virtual ICollection<GoodCard> GoodCards { get; set; }
        public virtual ICollection<GreenCard> GreenCards { get; set; }
        public virtual ICollection<Nutricash> Nutricashes { get; set; }
        public virtual ICollection<Omni> Omnis { get; set; }
        public virtual ICollection<PoliCard> PoliCards { get; set; }
        public virtual ICollection<Recebimento> Recebimentoes { get; set; }
        public virtual ICollection<RedeCard> RedeCards { get; set; }
        public virtual ICollection<RedeMed> RedeMeds { get; set; }
        public virtual ICollection<Sodexo> Sodexoes { get; set; }
        public virtual ICollection<TaxaAdministracao> TaxaAdministracaos { get; set; }
        public virtual ICollection<TicketCar> TicketCars { get; set; }
        public virtual ICollection<ValeCard> ValeCards { get; set; }
    }
}
