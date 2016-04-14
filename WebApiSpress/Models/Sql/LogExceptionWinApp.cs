using System;
using System.Collections.Generic;

namespace WebApiSpress.Models.Sql
{
    public partial class LogExceptionWinApp
    {
        public int Id { get; set; }
        public string Application { get; set; }
        public string Version { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
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
        public byte[] Status { get; set; }
        public int Id_Grupo { get; set; }
        public virtual grupo_empresa grupo_empresa { get; set; }
    }
}
