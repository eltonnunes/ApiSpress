using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class usuario
    {
        public usuario()
        {
            this.historico_senhas = new List<historico_senhas>();
        }

        public string cod_usuario { get; set; }
        public decimal nivel_usuario { get; set; }
        public string codlojasitef { get; set; }
        public string cod_grupo { get; set; }
        public string senha { get; set; }
        public string codaut { get; set; }
        public string ultimoacesso { get; set; }
        public string per_gera_arq { get; set; }
        public string per_conciliacao { get; set; }
        public decimal totalacessos { get; set; }
        public decimal num_tentativas { get; set; }
        public string cod_estado { get; set; }
        public string cod_regional { get; set; }
        public string per_valores { get; set; }
        public string per_confrel { get; set; }
        public string per_gercancelamento { get; set; }
        public string per_pesquisatrn { get; set; }
        public string per_relgerencial { get; set; }
        public Nullable<decimal> cpf { get; set; }
        public string nome { get; set; }
        public string console_config { get; set; }
        public string console_cleaner { get; set; }
        public decimal access_type { get; set; }
        public decimal devealterarsenha { get; set; }
        public string conciliacao_pos { get; set; }
        public Nullable<decimal> nivel_alerta { get; set; }
        public virtual estado_usuario estado_usuario { get; set; }
        public virtual Grupo Grupo { get; set; }
        public virtual ICollection<historico_senhas> historico_senhas { get; set; }
        public virtual Loja Loja { get; set; }
        public virtual nivel_usuarios nivel_usuarios { get; set; }
        public virtual regional regional { get; set; }
    }
}
