using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.Object
{
    public class ConciliaRecebimentoParcela
    {
        private Int32 idExtrato;
        public Int32 IdExtrato
        {
            get { return idExtrato; }
            set { idExtrato = value; }
        }

        private DateTime data;
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        private List<Int32> idsRecebimento;

        public List<Int32> IdsRecebimento
        {
            get { return idsRecebimento; }
            set { idsRecebimento = value; }
        }

    }

}