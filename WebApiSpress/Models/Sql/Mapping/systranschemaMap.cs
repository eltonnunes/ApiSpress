using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class systranschemaMap : EntityTypeConfiguration<systranschema>
    {
        public systranschemaMap()
        {
            // Primary Key
            this.HasKey(t => new { t.tabid, t.startlsn, t.endlsn, t.typeid });

            // Properties
            this.Property(t => t.tabid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.startlsn)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.endlsn)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.typeid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("systranschemas");
            this.Property(t => t.tabid).HasColumnName("tabid");
            this.Property(t => t.startlsn).HasColumnName("startlsn");
            this.Property(t => t.endlsn).HasColumnName("endlsn");
            this.Property(t => t.typeid).HasColumnName("typeid");
        }
    }
}
