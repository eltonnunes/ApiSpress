using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class tbCatalogo
    {
        public tbCatalogo()
        {
            this.tbNews = new List<tbNews>();
            this.tbNewsGrupoes = new List<tbNewsGrupos>();
        }

        public short cdCatalogo { get; set; }
        public string dsCatalogo { get; set; }
        public virtual ICollection<tbNews> tbNews { get; set; }
        public virtual ICollection<tbNewsGrupos> tbNewsGrupoes { get; set; }
    }
}