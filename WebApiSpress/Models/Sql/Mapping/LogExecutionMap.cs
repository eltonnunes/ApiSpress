using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class LogExecutionMap : EntityTypeConfiguration<LogExecution>
    {
        public LogExecutionMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.statusExecution)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("LogExecution", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idOperadora).HasColumnName("idOperadora");
            this.Property(t => t.dtaExecution).HasColumnName("dtaExecution");
            this.Property(t => t.dtaFiltroTransacoes).HasColumnName("dtaFiltroTransacoes");
            this.Property(t => t.qtdTransacoes).HasColumnName("qtdTransacoes");
            this.Property(t => t.vlTotalTransacoes).HasColumnName("vlTotalTransacoes");
            this.Property(t => t.statusExecution).HasColumnName("statusExecution");
            this.Property(t => t.idLoginOperadora).HasColumnName("idLoginOperadora");
            this.Property(t => t.dtaExecucaoInicio).HasColumnName("dtaExecucaoInicio");
            this.Property(t => t.dtaExecucaoFim).HasColumnName("dtaExecucaoFim");
            this.Property(t => t.dtaFiltroTransacoesFinal).HasColumnName("dtaFiltroTransacoesFinal");
            this.Property(t => t.dtaExecucaoProxima).HasColumnName("dtaExecucaoProxima");

            // Relationships
            this.HasOptional(t => t.LoginOperadora)
                .WithMany(t => t.LogExecutions)
                .HasForeignKey(d => d.idLoginOperadora);

        }
    }
}
