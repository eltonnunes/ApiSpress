using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Models.Object
{

    public class ConciliacaoBancaria
    {

        private string tipo; // "E" : extrato, "R" : RecebimentoParcela
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private DateTime data; // data do extrato ou do recebimento
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        private Nullable<DateTime> dataVenda; // data do extrato ou do recebimento
        public Nullable<DateTime> DataVenda
        {
            get { return dataVenda; }
            set { dataVenda = value; }
        }

        private List<ConciliacaoGrupo> grupo;
        public List<ConciliacaoGrupo> Grupo
        {
            get { return grupo; }
            set { grupo = value; }
        }

        private string adquirente; 
        public string Adquirente
        {
            get { return adquirente; }
            set { adquirente = value; }
        }

        private string bandeira;
        public string Bandeira
        {
            get { return bandeira; }
            set { bandeira = value; }
        }

        private string memo;
        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }

        private decimal valortotal;
        public decimal ValorTotal
        {
            get { return valortotal; }
            set { valortotal = value; }
        }

        private ConciliacaoConta conta; // conta bancária associada
        public ConciliacaoConta Conta
        {
            get { return conta; }
            set { conta = value; }
        }



        public class ConciliacaoGrupo
        {
            private Int32 id; // id do extrato ou do recebimento
            public Int32 Id
            {
                get { return id; }
                set { id = value; }
            }

            private decimal valor; // valor do Extrato ou valor liquido do recebimento parcela
            public decimal Valor
            {
                get { return valor; }
                set { valor = value; }
            }

            private string documento;
            public string Documento
            {
                get { return documento; }
                set { documento = value; }
            }

            private string bandeira;
            public string Bandeira
            {
                get { return bandeira; }
                set { bandeira = value; }
            }

            private Nullable<DateTime> dataVenda; // data do extrato ou do recebimento
            public Nullable<DateTime> DataVenda
            {
                get { return dataVenda; }
                set { dataVenda = value; }
            }
        }



        public class ConciliacaoConta
        {
            private Int32 cdContaCorrente;
            public Int32 CdContaCorrente
            {
                get { return cdContaCorrente; }
                set { cdContaCorrente = value; }
            }

            private string cdBanco;
            public string CdBanco
            {
                get { return cdBanco; }
                set { cdBanco = value; }
            }

            private string nrAgencia;
            public string NrAgencia
            {
                get { return nrAgencia; }
                set { nrAgencia = value; }
            }

            private string nrConta; 
            public string NrConta
            {
                get { return nrConta; }
                set { nrConta = value; }
            }

        }


        public class Comparer : IEqualityComparer<ConciliacaoBancaria>
        {
            public bool Equals(ConciliacaoBancaria c1, ConciliacaoBancaria c2)
            {
                if (c1 == c2) return true; // é a mesma instância ou ambos são nulos
                if (c1 == null || c2 == null) return false;
                return c1.Data.Year == c2.Data.Year && c1.Data.Month == c2.Data.Month && c1.Data.Day == c2.Data.Day &&
                       c1.ValorTotal == c2.ValorTotal && 
                       c1.Adquirente.Equals(c2.Adquirente);
            }

            public int GetHashCode(ConciliacaoBancaria c)
            {
                if (c == null) return 0;
                DateTime d = new DateTime(c.Data.Year, c.Data.Month, c.Data.Day);
                return ((int)d.Ticks) + c.Adquirente.GetHashCode() + ((int)c.ValorTotal);
            }
        }

    }
}
