using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbRedeTefMap : EntityTypeConfiguration<tbRedeTef>
    {
        public tbRedeTefMap()
        {
            // Primary Key
            this.HasKey(t => t.cdRedeTef);

            // Properties
            this.Property(t => t.cdRedeTef)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.dsRedeTef)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("tbRedeTef", "card");
            this.Property(t => t.cdRedeTef).HasColumnName("cdRedeTef");
            this.Property(t => t.dsRedeTef).HasColumnName("dsRedeTef");
        }
    }
}
