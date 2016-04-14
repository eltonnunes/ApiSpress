using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class LogExecutionExceptionMap : EntityTypeConfiguration<LogExecutionException>
    {
        public LogExecutionExceptionMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.textError)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("LogExecutionException", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idLogExecution).HasColumnName("idLogExecution");
            this.Property(t => t.textError).HasColumnName("textError");

            // Relationships
            this.HasRequired(t => t.LogExecution)
                .WithMany(t => t.LogExecutionExceptions)
                .HasForeignKey(d => d.idLogExecution);

        }
    }
}
