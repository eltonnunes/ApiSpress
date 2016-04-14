using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class newsletterMap : EntityTypeConfiguration<newsletter>
    {
        public newsletterMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(255);

            this.Property(t => t.descricao)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("newsletter", "newsletter");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.descricao).HasColumnName("descricao");
            this.Property(t => t.view).HasColumnName("view");
            this.Property(t => t.html).HasColumnName("html");
        }
    }
}
