using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class parametro_recepcao
    {
        public int id_parametroRecepcao { get; set; }
        public int id_grupoEmpresa { get; set; }
        public string ds_email { get; set; }
        public string ds_user { get; set; }
        public string ds_pass { get; set; }
        public Nullable<int> qt_emailsRecepcionar { get; set; }
        public Nullable<int> qt_emailsRecepcionados { get; set; }
        public int tp_statusRecepcao { get; set; }
        public Nullable<System.DateTime> dt_inicioRecepcao { get; set; }
        public Nullable<System.DateTime> dt_atualizacaoRecepcao { get; set; }
        public Nullable<System.DateTime> dt_fimRecepcao { get; set; }
        public Nullable<int> qt_emailsProcessar { get; set; }
        public Nullable<int> qt_emailsProcessados { get; set; }
        public int tp_statusProcessamento { get; set; }
        public Nullable<System.DateTime> dt_inicioProcessamento { get; set; }
        public Nullable<System.DateTime> dt_atualizacaoProcessamento { get; set; }
        public Nullable<System.DateTime> dt_fimProcessamento { get; set; }
        public Nullable<bool> tp_ssl { get; set; }
        public string ds_host { get; set; }
        public Nullable<int> nu_port { get; set; }
    }
}
