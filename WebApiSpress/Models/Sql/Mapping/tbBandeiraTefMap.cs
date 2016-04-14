using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbBandeiraTefMap : EntityTypeConfiguration<tbBandeiraTef>
    {
        public tbBandeiraTefMap()
        {
            // Primary Key
            this.HasKey(t => t.cdBandeiraTef);

            // Properties
            this.Property(t => t.cdBandeiraTef)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.dsBandeiraTef)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("tbBandeiraTef", "card");
            this.Property(t => t.cdBandeiraTef).HasColumnName("cdBandeiraTef");
            this.Property(t => t.dsBandeiraTef).HasColumnName("dsBandeiraTef");
        }
    }
}
