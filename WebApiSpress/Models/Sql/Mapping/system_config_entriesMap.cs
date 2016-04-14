using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class system_config_entriesMap : EntityTypeConfiguration<system_config_entries>
    {
        public system_config_entriesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.chave, t.section_id });

            // Properties
            this.Property(t => t.chave)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.valor)
                .HasMaxLength(255);

            this.Property(t => t.section_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("system_config_entries");
            this.Property(t => t.chave).HasColumnName("chave");
            this.Property(t => t.valor).HasColumnName("valor");
            this.Property(t => t.section_id).HasColumnName("section_id");

            // Relationships
            this.HasRequired(t => t.system_config_section)
                .WithMany(t => t.system_config_entries)
                .HasForeignKey(d => d.section_id);

        }
    }
}
