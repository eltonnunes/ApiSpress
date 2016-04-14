using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class qrtz_fired_triggersMap : EntityTypeConfiguration<qrtz_fired_triggers>
    {
        public qrtz_fired_triggersMap()
        {
            // Primary Key
            this.HasKey(t => t.entry_id);

            // Properties
            this.Property(t => t.entry_id)
                .IsRequired()
                .HasMaxLength(95);

            this.Property(t => t.trigger_name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.trigger_group)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.is_volatile)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.instance_name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.state)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.job_name)
                .HasMaxLength(200);

            this.Property(t => t.job_group)
                .HasMaxLength(200);

            this.Property(t => t.is_stateful)
                .HasMaxLength(1);

            this.Property(t => t.requests_recovery)
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("qrtz_fired_triggers");
            this.Property(t => t.entry_id).HasColumnName("entry_id");
            this.Property(t => t.trigger_name).HasColumnName("trigger_name");
            this.Property(t => t.trigger_group).HasColumnName("trigger_group");
            this.Property(t => t.is_volatile).HasColumnName("is_volatile");
            this.Property(t => t.instance_name).HasColumnName("instance_name");
            this.Property(t => t.fired_time).HasColumnName("fired_time");
            this.Property(t => t.priority).HasColumnName("priority");
            this.Property(t => t.state).HasColumnName("state");
            this.Property(t => t.job_name).HasColumnName("job_name");
            this.Property(t => t.job_group).HasColumnName("job_group");
            this.Property(t => t.is_stateful).HasColumnName("is_stateful");
            this.Property(t => t.requests_recovery).HasColumnName("requests_recovery");
        }
    }
}
