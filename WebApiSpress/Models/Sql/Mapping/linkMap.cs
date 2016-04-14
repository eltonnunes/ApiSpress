using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class linkMap : EntityTypeConfiguration<link>
    {
        public linkMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(255);

            this.Property(t => t.url)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("links", "newsletter");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.url).HasColumnName("url");
            this.Property(t => t.view).HasColumnName("view");
        }
    }
}
