using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbCanalMap : EntityTypeConfiguration<tbCanal>
    {
        public tbCanalMap()
        {
            // Primary Key
            this.HasKey(t => t.cdCanal);

            // Properties
            this.Property(t => t.cdCanal)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.dsCanal)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tbCanal", "admin");
            this.Property(t => t.cdCanal).HasColumnName("cdCanal");
            this.Property(t => t.dsCanal).HasColumnName("dsCanal");
        }
    }
}