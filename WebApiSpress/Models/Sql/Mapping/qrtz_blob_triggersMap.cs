using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class qrtz_blob_triggersMap : EntityTypeConfiguration<qrtz_blob_triggers>
    {
        public qrtz_blob_triggersMap()
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
            this.ToTable("qrtz_blob_triggers");
            this.Property(t => t.trigger_name).HasColumnName("trigger_name");
            this.Property(t => t.trigger_group).HasColumnName("trigger_group");
            this.Property(t => t.blob_data).HasColumnName("blob_data");

            // Relationships
            this.HasRequired(t => t.qrtz_triggers)
                .WithOptional(t => t.qrtz_blob_triggers);

        }
    }
}
