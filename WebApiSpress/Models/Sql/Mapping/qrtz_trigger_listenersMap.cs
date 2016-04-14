using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class qrtz_trigger_listenersMap : EntityTypeConfiguration<qrtz_trigger_listeners>
    {
        public qrtz_trigger_listenersMap()
        {
            // Primary Key
            this.HasKey(t => new { t.trigger_name, t.trigger_group, t.trigger_listener });

            // Properties
            this.Property(t => t.trigger_name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.trigger_group)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.trigger_listener)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("qrtz_trigger_listeners");
            this.Property(t => t.trigger_name).HasColumnName("trigger_name");
            this.Property(t => t.trigger_group).HasColumnName("trigger_group");
            this.Property(t => t.trigger_listener).HasColumnName("trigger_listener");

            // Relationships
            this.HasRequired(t => t.qrtz_triggers)
                .WithMany(t => t.qrtz_trigger_listeners)
                .HasForeignKey(d => new { d.trigger_name, d.trigger_group });

        }
    }
}
