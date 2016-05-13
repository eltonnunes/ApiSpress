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
        public int CLIENTNRO;
        public int MODCODBANORI;
        public int MODCODAGEORI;
        public int MODCODBANATU;
        public int MODCODAGEATU;
        public int MODNROPARCELAS;
        public string EXPMONCOD;
        public string MODNROCARTAO;
        public string K0;
        public string MODIDTSITUACAO;
        public decimal MODVLR;
        public decimal MODVLRTXFHIST;
        public string MODCODCONORI;
        public string MODCODCONATU;

        // Específicos : CAC
        public int CACMODDATPRORROG;
        public string CACADMIDTREGISTRO;
        public string CACMODIDTFORMA;

        // Específicos : CAB
        public int CABMODNRODIAREC; // dias receb
        public int BANCOSCOD;
        public int AGEBANCOD;
        public string CONCORNRO;

        public VendaSpress()
        {
            this.TIPO = ' ';
            this.ADMCOD = 0;
            this.RECEBINRO = 0;
            this.MODDATREGISTRO = 0;
            this.RESNRO = 0;
            this.MODSEQ = 0;
            this.MODCODBANORI = 0;
            this.MODCODAGEORI = 0;
            this.MODCODBANATU = 0;
            this.MODCODAGEATU = 0;
            this.MODNROPARCELAS = 0;
            this.CLIENTNRO = 0;
            this.EXPMONCOD = String.Empty;
            this.MODNROCARTAO = String.Empty;
            this.K0 = String.Empty;
            this.MODIDTSITUACAO = String.Empty;
            this.MODVLR = new decimal(0.0);
            this.MODVLRTXFHIST = new decimal(0.0);
            this.MODCODCONORI = String.Empty;
            this.MODCODCONATU = String.Empty;

            // CAC
            this.CACMODDATPRORROG = 0;
            this.CACADMIDTREGISTRO = String.Empty;
            this.CACMODIDTFORMA = String.Empty;

            // CAB
            this.CABMODNRODIAREC = 0;
            this.BANCOSCOD = 0;
            this.AGEBANCOD = 0;
            this.CONCORNRO = String.Empty;
        }
    }
}