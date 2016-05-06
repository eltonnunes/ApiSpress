using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSpress.Models.Object
{
    public class VendaSpress
    {
        public char TIPO;
        public int ADMCOD;
        public int RECEBINRO;
        public int MODDATREGISTRO;
        public int RESNRO;
        public int MODSEQ;
        public int PARCODBANATU;
        public int PARCODAGEATU;
        public int MODNROPARCELAS;
        public string EXPMONCOD;
        public string PARNROCONATU;
        public string MODNROCARTAO;
        public string K0;
        public string MODIDTSITUACAO;

        public VendaSpress()
        {
            this.TIPO = ' ';
            this.ADMCOD = 0;
            this.RECEBINRO = 0;
            this.MODDATREGISTRO = 0;
            this.RESNRO = 0;
            this.MODSEQ = 0;
            this.PARCODBANATU = 0;
            this.PARCODAGEATU = 0;
            this.MODNROPARCELAS = 0;
            this.EXPMONCOD = String.Empty;
            this.PARNROCONATU = String.Empty;
            this.MODNROCARTAO = String.Empty;
            this.K0 = String.Empty;
            this.MODIDTSITUACAO = String.Empty;
        }
    }
}