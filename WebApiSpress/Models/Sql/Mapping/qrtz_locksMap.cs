using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class qrtz_locksMap : EntityTypeConfiguration<qrtz_locks>
    {
        public qrtz_locksMap()
        {
            // Primary Key
            this.HasKey(t => t.lock_name);

            // Properties
            this.Property(t => t.lock_name)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("qrtz_locks");
            this.Property(t => t.lock_name).HasColumnName("lock_name");
        }
    }
}
