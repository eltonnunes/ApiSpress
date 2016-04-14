using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class recepcao_email
    {
        public recepcao_email()
        {
            this.arquivo_email = new List<arquivo_email>();
        }

        public int id_recepcaoEmail { get; set; }
        public string ds_from { get; set; }
        public string ds_cc { get; set; }
        public string ds_bcc { get; set; }
        public string ds_subject { get; set; }
        public string ds_body { get; set; }
        public System.DateTime dt_recepcao { get; set; }
        public Nullable<System.DateTime> dt_resposta { get; set; }
        public int fl_status { get; set; }
        public int id_parametroRecepcao { get; set; }
        public virtual ICollection<arquivo_email> arquivo_email { get; set; }
    }
}
