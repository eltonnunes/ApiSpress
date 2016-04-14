using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class log_eventos_dados
    {
        public decimal id_log { get; set; }
        public decimal sequencia { get; set; }
        public string operacao { get; set; }
        public string sessao { get; set; }
        public string param { get; set; }
        public string valor { get; set; }
        public string valor_ant { get; set; }
        public virtual log_eventos log_eventos { get; set; }
    }
}
