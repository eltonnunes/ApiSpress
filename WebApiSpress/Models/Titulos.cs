using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSpress.Models
{
    public class Titulos
    {
        public Titulos()
        {
            this.val_liquido = this.val_original - this.val_taxa_cobranca;
        }


        public int seq_titulo { get; set; }
        public int cod_empresa { get; set; }
        public string num_titulo { get; set; }
        public int cod_pessoa_sacado { get; set; }
        public DateTime dta_emissao { get; set; }
        public string num_nsu_tef { get; set; }
        public string num_cnpj { get; set; }
        public string nom_pessoa { get; set; }
        public string nom_fantasia { get; set; }
        public Double val_original { get; set; }
        public Double val_taxa_cobranca { get; set; }
        public Double val_liquido { get; set; }
        public Double val_liquidado { get; set; }
        public Int32 qtd_parcelas { get; set; }
        public Int32 num_parcela { get; set; }
        public string ind_status { get; set; }
    }
}
