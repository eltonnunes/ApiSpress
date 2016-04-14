using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class MSpeer_lsnsMap : EntityTypeConfiguration<MSpeer_lsns>
    {
        public MSpeer_lsnsMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.originator)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.originator_db)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.originator_publication)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.originator_lsn)
                .HasMaxLength(16);

            // Table & Column Mappings
            this.ToTable("MSpeer_lsns");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.last_updated).HasColumnName("last_updated");
            this.Property(t => t.originator).HasColumnName("originator");
            this.Property(t => t.originator_db).HasColumnName("originator_db");
            this.Property(t => t.originator_publication).HasColumnName("originator_publication");
            this.Property(t => t.originator_publication_id).HasColumnName("originator_publication_id");
            this.Property(t => t.originator_db_version).HasColumnName("originator_db_version");
            this.Property(t => t.originator_lsn).HasColumnName("originator_lsn");
        }
    }
}
