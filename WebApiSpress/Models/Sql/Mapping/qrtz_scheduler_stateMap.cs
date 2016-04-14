using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class qrtz_scheduler_stateMap : EntityTypeConfiguration<qrtz_scheduler_state>
    {
        public qrtz_scheduler_stateMap()
        {
            // Primary Key
            this.HasKey(t => t.instance_name);

            // Properties
            this.Property(t => t.instance_name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("qrtz_scheduler_state");
            this.Property(t => t.instance_name).HasColumnName("instance_name");
            this.Property(t => t.last_checkin_time).HasColumnName("last_checkin_time");
            this.Property(t => t.checkin_interval).HasColumnName("checkin_interval");
        }
    }
}
