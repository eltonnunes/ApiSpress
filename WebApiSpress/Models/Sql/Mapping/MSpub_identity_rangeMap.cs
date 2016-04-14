using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class MSpub_identity_rangeMap : EntityTypeConfiguration<MSpub_identity_range>
    {
        public MSpub_identity_rangeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.objid, t.range, t.pub_range, t.current_pub_range, t.threshold });

            // Properties
            this.Property(t => t.objid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.range)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.pub_range)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.current_pub_range)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.threshold)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSpub_identity_range");
            this.Property(t => t.objid).HasColumnName("objid");
            this.Property(t => t.range).HasColumnName("range");
            this.Property(t => t.pub_range).HasColumnName("pub_range");
            this.Property(t => t.current_pub_range).HasColumnName("current_pub_range");
            this.Property(t => t.threshold).HasColumnName("threshold");
            this.Property(t => t.last_seed).HasColumnName("last_seed");
        }
    }
}
