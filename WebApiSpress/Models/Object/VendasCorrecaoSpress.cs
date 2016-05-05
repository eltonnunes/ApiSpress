using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSpress.Models.Object
{
    public class VendasCorrecaoSpress
    {
        // Informações da adquirente
        public int R_id;
        public string R_cnpj;
        public string R_nsu;
        public int R_cdAdquirente;
        public string R_codResumoVenda;
        public DateTime R_dtVenda;
        public string R_cdSacado;
        public decimal R_vlVenda;
        public Nullable<int> R_qtParcelas;
        // Informações do ERP
        public int V_id;
        public int? V_cdAdquirente;
        public string V_cnpj;
        public string V_nsu;
        public DateTime V_dtVenda;
        public string V_cdSacado;
        public decimal V_vlVenda;
        public Nullable<int> V_qtParcelas;
        public string V_cdERP;
    }
}