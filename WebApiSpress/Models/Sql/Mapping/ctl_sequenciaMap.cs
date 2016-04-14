using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class ctl_sequenciaMap : EntityTypeConfiguration<ctl_sequencia>
    {
        public ctl_sequenciaMap()
        {
            // Primary Key
            this.HasKey(t => new { t.aplicacao, t.id_sequencia });

            // Properties
            this.Property(t => t.aplicacao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.id_sequencia)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("ctl_sequencia");
            this.Property(t => t.aplicacao).HasColumnName("aplicacao");
            this.Property(t => t.id_sequencia).HasColumnName("id_sequencia");
            this.Property(t => t.sequencia).HasColumnName("sequencia");
        }
    }
}
