using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class arquivo_email
    {
        public int id_arquivoEmail { get; set; }
        public int id_recepcaoEmail { get; set; }
        public string ds_nomeArquivo { get; set; }
        public string ds_extensao { get; set; }
        public string ds_arquivo { get; set; }
        public int fl_status { get; set; }
        public virtual recepcao_email recepcao_email { get; set; }
    }
}
