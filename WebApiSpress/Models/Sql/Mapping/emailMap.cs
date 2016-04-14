using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class emailMap : EntityTypeConfiguration<email>
    {
        public emailMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(255);

            this.Property(t => t.email1)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("emails", "newsletter");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.email1).HasColumnName("email");
        }
    }
}
