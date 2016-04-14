using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSpress.Models.Object
{
    public class Pdv
    {
        public Int32 cod_pdv;
        public string des_pdv;
    }

    public class Sacado
    {
        public Int32 cod_pessoa;
        public string nom_pessoa;
    }

    public class Empresa
    {
        public Int32 cod_empresa;
        public string nom_razao_social;
        public string nom_fantasia;
        public string num_cnpj;
    }
    public class pagto
    {
        public Int32 cod_forma_pagto;
        public string des_forma_pagto;
        public Int32 cod_pessoa_sacado;
    }

    public class pagtoNfs
    {
        public Int32 sequencia; // seq_cupom ou seq_nota
        public Int32 seq_pagamento;
        public string num_autorizacao;
    }

    public class PDV
    {
        public Int32 sequencia; // seq_cupom ou seq_nota
        public string tipo; // "C" : Cupom Fiscal, "N" : Nota Fiscal
        public int seq_pagamento; // compõe a chave do pagamento
        public Nullable<DateTime> data;
        public string hora;
        public double valor;
        public Pdv pdv;
        public Empresa empresa;
        public string num_autorizacao;
        public Sacado sacado;
        public pagto pagto_pdv;


        public PDV()
        {
            this.sequencia = 0;
            this.tipo = String.Empty;
            this.seq_pagamento = 0;
            this.data = null;
            this.hora = String.Empty;
            this.valor = 0.0;
            this.pdv = new Pdv();
            this.empresa = new Empresa();
            this.sacado = new Sacado();
            this.num_autorizacao = String.Empty;
            this.pagto_pdv = new pagto();
        }
    }
}
