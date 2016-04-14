using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class descmeiospagMap : EntityTypeConfiguration<descmeiospag>
    {
        public descmeiospagMap()
        {
            // Primary Key
            this.HasKey(t => t.finalizadora);

            // Properties
            this.Property(t => t.finalizadora)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.descmeiopag)
                .HasMaxLength(20);

            this.Property(t => t.exibe)
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("descmeiospag");
            this.Property(t => t.finalizadora).HasColumnName("finalizadora");
            this.Property(t => t.descmeiopag).HasColumnName("descmeiopag");
            this.Property(t => t.exibe).HasColumnName("exibe");
        }
    }
}
