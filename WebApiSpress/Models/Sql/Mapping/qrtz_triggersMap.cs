using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class qrtz_triggersMap : EntityTypeConfiguration<qrtz_triggers>
    {
        public qrtz_triggersMap()
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

            this.Property(t => t.job_name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.job_group)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.is_volatile)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.description)
                .HasMaxLength(250);

            this.Property(t => t.trigger_state)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.trigger_type)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.calendar_name)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("qrtz_triggers");
            this.Property(t => t.trigger_name).HasColumnName("trigger_name");
            this.Property(t => t.trigger_group).HasColumnName("trigger_group");
            this.Property(t => t.job_name).HasColumnName("job_name");
            this.Property(t => t.job_group).HasColumnName("job_group");
            this.Property(t => t.is_volatile).HasColumnName("is_volatile");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.next_fire_time).HasColumnName("next_fire_time");
            this.Property(t => t.prev_fire_time).HasColumnName("prev_fire_time");
            this.Property(t => t.priority).HasColumnName("priority");
            this.Property(t => t.trigger_state).HasColumnName("trigger_state");
            this.Property(t => t.trigger_type).HasColumnName("trigger_type");
            this.Property(t => t.start_time).HasColumnName("start_time");
            this.Property(t => t.end_time).HasColumnName("end_time");
            this.Property(t => t.calendar_name).HasColumnName("calendar_name");
            this.Property(t => t.misfire_instr).HasColumnName("misfire_instr");
            this.Property(t => t.job_data).HasColumnName("job_data");

            // Relationships
            this.HasRequired(t => t.qrtz_job_details)
                .WithMany(t => t.qrtz_triggers)
                .HasForeignKey(d => new { d.job_name, d.job_group });

        }
    }
}
