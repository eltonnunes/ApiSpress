using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class LogExceptionWinAppMap : EntityTypeConfiguration<LogExceptionWinApp>
    {
        public LogExceptionWinAppMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Application)
                .HasMaxLength(255);

            this.Property(t => t.Version)
                .HasMaxLength(255);

            this.Property(t => t.ComputerName)
                .HasMaxLength(255);

            this.Property(t => t.UserName)
                .HasMaxLength(255);

            this.Property(t => t.OSVersion)
                .HasMaxLength(255);

            this.Property(t => t.CurrentCulture)
                .HasMaxLength(255);

            this.Property(t => t.Resolution)
                .HasMaxLength(255);

            this.Property(t => t.SystemUpTime)
                .HasMaxLength(255);

            this.Property(t => t.TotalMemory)
                .HasMaxLength(255);

            this.Property(t => t.AvailableMemory)
                .HasMaxLength(255);

            this.Property(t => t.ExceptionClasses)
                .HasMaxLength(255);

            this.Property(t => t.ExceptionMessages)
                .HasMaxLength(255);

            this.Property(t => t.StackTraces)
                .HasMaxLength(255);

            this.Property(t => t.LoadedModules)
                .HasMaxLength(255);

            this.Property(t => t.Status)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("LogExceptionWinApp", "admin");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Application).HasColumnName("Application");
            this.Property(t => t.Version).HasColumnName("Version");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.ComputerName).HasColumnName("ComputerName");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.OSVersion).HasColumnName("OSVersion");
            this.Property(t => t.CurrentCulture).HasColumnName("CurrentCulture");
            this.Property(t => t.Resolution).HasColumnName("Resolution");
            this.Property(t => t.SystemUpTime).HasColumnName("SystemUpTime");
            this.Property(t => t.TotalMemory).HasColumnName("TotalMemory");
            this.Property(t => t.AvailableMemory).HasColumnName("AvailableMemory");
            this.Property(t => t.ExceptionClasses).HasColumnName("ExceptionClasses");
            this.Property(t => t.ExceptionMessages).HasColumnName("ExceptionMessages");
            this.Property(t => t.StackTraces).HasColumnName("StackTraces");
            this.Property(t => t.LoadedModules).HasColumnName("LoadedModules");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Id_Grupo).HasColumnName("Id_Grupo");

            // Relationships
            this.HasRequired(t => t.grupo_empresa)
                .WithMany(t => t.LogExceptionWinApps)
                .HasForeignKey(d => d.Id_Grupo);

        }
    }
}
