using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class columnmodelMap : EntityTypeConfiguration<columnmodel>
    {
        public columnmodelMap()
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

            this.Property(t => t.versao)
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("columnmodel");
            this.Property(t => t.module).HasColumnName("module");
            this.Property(t => t.submodule).HasColumnName("submodule");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.model).HasColumnName("model");
            this.Property(t => t.versao).HasColumnName("versao");
        }
    }
}
