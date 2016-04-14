using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class qrtz_simple_triggersMap : EntityTypeConfiguration<qrtz_simple_triggers>
    {
        public qrtz_simple_triggersMap()
        {
            // Primary Key
            this.HasKey(t => new { t.trigger_name, t.trigger_group });

            // Properties
            this.Property(t => t.trigger_name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.trigger_group)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("qrtz_simple_triggers");
            this.Property(t => t.trigger_name).HasColumnName("trigger_name");
            this.Property(t => t.trigger_group).HasColumnName("trigger_group");
            this.Property(t => t.repeat_count).HasColumnName("repeat_count");
            this.Property(t => t.repeat_interval).HasColumnName("repeat_interval");
            this.Property(t => t.times_triggered).HasColumnName("times_triggered");

            // Relationships
            this.HasRequired(t => t.qrtz_triggers)
                .WithOptional(t => t.qrtz_simple_triggers);

        }
    }
}
