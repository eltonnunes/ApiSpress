using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class qrtz_cron_triggersMap : EntityTypeConfiguration<qrtz_cron_triggers>
    {
        public qrtz_cron_triggersMap()
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

            this.Property(t => t.cron_expression)
                .IsRequired()
                .HasMaxLength(120);

            this.Property(t => t.time_zone_id)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("qrtz_cron_triggers");
            this.Property(t => t.trigger_name).HasColumnName("trigger_name");
            this.Property(t => t.trigger_group).HasColumnName("trigger_group");
            this.Property(t => t.cron_expression).HasColumnName("cron_expression");
            this.Property(t => t.time_zone_id).HasColumnName("time_zone_id");

            // Relationships
            this.HasRequired(t => t.qrtz_triggers)
                .WithOptional(t => t.qrtz_cron_triggers);

        }
    }
}
