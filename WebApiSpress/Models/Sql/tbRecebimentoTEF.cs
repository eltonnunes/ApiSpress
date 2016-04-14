using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tbRecebimentoTEF
    {
        public int idRecebimentoTEF { get; set; }
        public Nullable<byte> cdGrupo { get; set; }
        public string nrCNPJ { get; set; }
        public string cdEmpresaTEF { get; set; }
        public string nrPDVTEF { get; set; }
        public string nrNSUHost { get; set; }
        public string nrNSUTEF { get; set; }
        public string cdAutorizacao { get; set; }
        public int cdSituacaoRedeTEF { get; set; }
        public System.DateTime dtVenda { get; set; }
        public System.TimeSpan hrVenda { get; set; }
        public decimal vlVenda { get; set; }
        public Nullable<byte> qtParcelas { get; set; }
        public string nrCartao { get; set; }
        public short cdBandeira { get; set; }
        public string nmOperadora { get; set; }
        public Nullable<System.DateTime> dthrVenda { get; set; }
        public Nullable<byte> cdEstadoTransacaoTEF { get; set; }
        public Nullable<int> cdTrasacaoTEF { get; set; }
        public Nullable<short> cdModoEntradaTEF { get; set; }
        public Nullable<short> cdRedeTEF { get; set; }
        public Nullable<short> cdProdutoTEF { get; set; }
        public Nullable<short> cdBandeiraTEF { get; set; }
        public string cdEstabelecimentoHost { get; set; }
    }
}
