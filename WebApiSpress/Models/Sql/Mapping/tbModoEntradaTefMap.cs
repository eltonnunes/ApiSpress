using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbModoEntradaTefMap : EntityTypeConfiguration<tbModoEntradaTef>
    {
        public tbModoEntradaTefMap()
        {
            // Primary Key
            this.HasKey(t => t.cdModoEntradaTef);

            // Properties
            this.Property(t => t.cdModoEntradaTef)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.dsModoEntradaTef)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("tbModoEntradaTef", "card");
            this.Property(t => t.cdModoEntradaTef).HasColumnName("cdModoEntradaTef");
            this.Property(t => t.dsModoEntradaTef).HasColumnName("dsModoEntradaTef");
        }
    }
}
