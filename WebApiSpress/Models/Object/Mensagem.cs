using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSpress.Models.Object
{
    public class Mensagem
    {
        public Mensagem()
        {
            Erro = new List<Erro>();
        }
        public int sqNota { get; set; }
        public int cdMensagem { get; set; }
        public List<Erro> Erro { get; set; }
    }

    public class Erro
    {
        public Erro(string mensagemErro)
        {
            this.mensagemErro = mensagemErro;
        }
        public string mensagemErro { get; set; }
    }
}