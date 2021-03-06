﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSpress.Models.Object
{
    public class Retorno
    {
        private List<dynamic> registros;

        public List<dynamic> Registros
        {
            get { return registros; }
            set { registros = value; }
        }

        private int totalDeRegistros;

        public int TotalDeRegistros
        {
            get { return totalDeRegistros; }
            set { totalDeRegistros = value; }
        }

        private int itensPorPagina;

        public int ItensPorPagina
        {
            get { return itensPorPagina; }
            set { itensPorPagina = value; }
        }

        private int paginaAtual;

        public int PaginaAtual
        {
            get { return paginaAtual; }
            set { paginaAtual = value; }
        }
    }
}