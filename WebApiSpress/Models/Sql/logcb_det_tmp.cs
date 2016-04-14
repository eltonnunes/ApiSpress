using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class logcb_det_tmp
    {
        public decimal cod_sit { get; set; }
        public string data_sitef { get; set; }
        public string nsu_sitef { get; set; }
        public string codlojasitef { get; set; }
        public decimal seq { get; set; }
        public Nullable<decimal> origem { get; set; }
        public string cod_originador { get; set; }
        public string formapagto_det { get; set; }
        public Nullable<int> formapagto { get; set; }
        public string valor { get; set; }
        public Nullable<decimal> modoentradacheque { get; set; }
        public string cmc7 { get; set; }
        public string host_tef { get; set; }
        public string nsu_host_tef { get; set; }
        public string data_tef { get; set; }
        public string cod_estab_tef { get; set; }
        public string codlojasitef_tef { get; set; }
        public string nro_recibo { get; set; }
        public Nullable<decimal> banco { get; set; }
        public Nullable<decimal> agencia { get; set; }
        public Nullable<decimal> conta { get; set; }
        public string digito { get; set; }
        public Nullable<decimal> cpf_cnpj { get; set; }
        public Nullable<decimal> codigo_receita { get; set; }
        public Nullable<decimal> codigo_pagto { get; set; }
        public Nullable<decimal> identificardor { get; set; }
        public string nsusiteftef { get; set; }
        public Nullable<decimal> codredetef { get; set; }
        public Nullable<decimal> funcaotef { get; set; }
    }
}
