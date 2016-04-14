using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models.Object
{
    public class RecebimentosParcela
    {
        private DateTime dtaRecebimentoAtual;
        public DateTime DtaRecebimentoAtual
        {
            get { return dtaRecebimentoAtual; }
            set { dtaRecebimentoAtual = value; }
        }

        private DateTime dtaRecebimentoNova;
        public DateTime DtaRecebimentoNova
        {
            get { return dtaRecebimentoNova; }
            set { dtaRecebimentoNova = value; }
        }

        private List<Int32> idsRecebimento;
        public List<Int32> IdsRecebimento
        {
            get { return idsRecebimento; }
            set { idsRecebimento = value; }
        }
    }
}
