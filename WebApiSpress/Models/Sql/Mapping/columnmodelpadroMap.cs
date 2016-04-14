using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class columnmodelpadroMap : EntityTypeConfiguration<columnmodelpadro>
    {
        public columnmodelpadroMap()
        {
            // Primary Key
            this.HasKey(t => new { t.module, t.name });

            // Properties
            this.Property(t => t.module)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.submodule)
                .HasMaxLength(256);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("columnmodelpadroes");
            this.Property(t => t.module).HasColumnName("module");
            this.Property(t => t.submodule).HasColumnName("submodule");
            this.Property(t => t.name).HasColumnName("name");
        }
    }
}
