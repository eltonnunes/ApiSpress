using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSpress.Models.Sql.Mapping
{
    [Table("Recebimento", Schema = "pos")]
    public class Recebimento
    {
        public int IdRecebimento { get; set; }
        public int idBandeira { get; set; }
        public string cnpj { get; set; }
        public string nsu { get; set; }
        public string cdAutorizador { get; set; }
        public DateTime dtaVenda { get; set; }
        public decimal valorVendaBruta { get; set; }
        public decimal valorVendaLiquida { get; set; }
        public string loteImportacao { get; set; }
        public DateTime dtaRecebimento { get; set; }
        public int idLogicoTerminal { get; set; }
    }
}
