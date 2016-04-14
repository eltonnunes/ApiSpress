using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.Object
{
    public class AlterarSenha
    {
        private string senhaAtual;
        public string SenhaAtual
        {
            get { return senhaAtual; }
            set { senhaAtual = value; }
        }

        private string novaSenha;
        public string NovaSenha
        {
            get { return novaSenha; }
            set { novaSenha = value; }
        }

        private Int32 userId;
        public Int32 UserId
        {
            get { return userId; }
            set { userId = value; }
        }

    }
}