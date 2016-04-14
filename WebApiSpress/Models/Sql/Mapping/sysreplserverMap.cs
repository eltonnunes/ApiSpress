using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class sysreplserverMap : EntityTypeConfiguration<sysreplserver>
    {
        public sysreplserverMap()
        {
            // Primary Key
            this.HasKey(t => t.srvname);

            // Properties
            this.Property(t => t.srvname)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("sysreplservers");
            this.Property(t => t.srvname).HasColumnName("srvname");
            this.Property(t => t.srvid).HasColumnName("srvid");
        }
    }
}
