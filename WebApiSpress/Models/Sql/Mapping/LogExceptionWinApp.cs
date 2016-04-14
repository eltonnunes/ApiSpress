using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Assistente_de_Fechamento_de_Caixa.Models.Sql.Mapping
{
    [Table("LogExceptionWinApp", Schema = "admin")]
    public class LogExceptionWinApp
    {
        [Key]
        public int Id { get; set; }
        public string Application { get; set; }
        public string Version { get; set; }
        public DateTime Date { get; set; }
        public string ComputerName { get; set; }
        public string UserName { get; set; }
        public string OSVersion { get; set; }
        public string CurrentCulture { get; set; }
        public string Resolution { get; set; }
        public string SystemUpTime { get; set; }
        public string TotalMemory { get; set; }
        public string AvailableMemory { get; set; }
        public string ExceptionClasses { get; set; }
        public string ExceptionMessages { get; set; }
        public string StackTraces { get; set; }
        public string LoadedModules { get; set; }
        public Boolean Status { get; set; }
        public int Id_Grupo { get; set; }

    }
}
