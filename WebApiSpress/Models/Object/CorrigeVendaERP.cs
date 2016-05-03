using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSpress.Models.Object
{
    public class CorrigeVendaERP
    {
        public List<int> idsRecebimento;

        public CorrigeVendaERP(List<int> idsRecebimento)
        {
            this.idsRecebimento = idsRecebimento;
        }
    }
}