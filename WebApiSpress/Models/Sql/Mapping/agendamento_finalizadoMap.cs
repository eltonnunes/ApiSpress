using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class agendamento_finalizadoMap : EntityTypeConfiguration<agendamento_finalizado>
    {
        public agendamento_finalizadoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.modulo, t.data_exe });

            // Properties
            this.Property(t => t.modulo)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.data_exe)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(16);

            this.Property(t => t.status)
                .HasMaxLength(100);

            this.Property(t => t.node_id)
                .HasMaxLength(255);

            this.Property(t => t.task_name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("agendamento_finalizado");
            this.Property(t => t.modulo).HasColumnName("modulo");
            this.Property(t => t.data_exe).HasColumnName("data_exe");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.node_id).HasColumnName("node_id");
            this.Property(t => t.task_name).HasColumnName("task_name");
        }
    }
}
