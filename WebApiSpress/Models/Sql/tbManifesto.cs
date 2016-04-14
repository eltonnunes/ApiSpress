using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebApiSpress.Models.Sql
{
    public partial class tbManifesto
    {
        public int idManifesto { get; set; }
        public string nrChave { get; set; }
        public string nrNSU { get; set; }
        public int cdGrupo { get; set; }
        public string nrCNPJ { get; set; }
        public string nrEmitenteCNPJCPF { get; set; }
        public string nmEmitente { get; set; }
        public string nrEmitenteIE { get; set; }
        public Nullable<System.DateTime> dtEmissao { get; set; }
        public string tpOperacao { get; set; }
        public Nullable<decimal> vlNFe { get; set; }
        public Nullable<System.DateTime> dtRecebimento { get; set; }
        public string cdSituacaoNFe { get; set; }
        public Nullable<short> cdSituacaoManifesto { get; set; }
        public string dsSituacaoManifesto { get; set; }
        public string nrProtocoloManifesto { get; set; }
        public string xmlNFe { get; set; }

        [NotMapped]
        public dynamic xmlNFeJson { get; set; }


        public string nrProtocoloDownload { get; set; }
        public Nullable<short> cdSituacaoDownload { get; set; }
        public string dsSituacaoDownload { get; set; }
        public Nullable<System.DateTime> dtEntrega { get; set; }
        public Nullable<int> idUsers { get; set; }
        public Nullable<bool> flEntrega { get; set; }
        public Nullable<System.DateTime> dtImportacao { get; set; }
        public Nullable<int> idUsersImportacao { get; set; }
        public tbManifesto()
        {
            //if(xmlNFe !=null) xmlNFeJson = Bibliotecas.nfeRead.Loader(xmlNFe);
        }
    }
}