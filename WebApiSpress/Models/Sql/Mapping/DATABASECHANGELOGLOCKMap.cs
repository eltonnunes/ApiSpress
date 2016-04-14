using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class DATABASECHANGELOGLOCKMap : EntityTypeConfiguration<DATABASECHANGELOGLOCK>
    {
        public DATABASECHANGELOGLOCKMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.LOCKEDBY)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("DATABASECHANGELOGLOCK");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.LOCKED).HasColumnName("LOCKED");
            this.Property(t => t.LOCKGRANTED).HasColumnName("LOCKGRANTED");
            this.Property(t => t.LOCKEDBY).HasColumnName("LOCKEDBY");
        }
    }
}
