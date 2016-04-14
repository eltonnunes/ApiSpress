using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class config_sectionMap : EntityTypeConfiguration<config_section>
    {
        public config_sectionMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.nome)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.aplicacao)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("config_section");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.nome).HasColumnName("nome");
            this.Property(t => t.aplicacao).HasColumnName("aplicacao");
            this.Property(t => t.se_cliente).HasColumnName("se_cliente");
            this.Property(t => t.id_schema).HasColumnName("id_schema");
        }
    }
}
