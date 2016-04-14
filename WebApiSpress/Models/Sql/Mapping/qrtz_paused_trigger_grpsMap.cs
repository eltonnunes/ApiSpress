using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class qrtz_paused_trigger_grpsMap : EntityTypeConfiguration<qrtz_paused_trigger_grps>
    {
        public qrtz_paused_trigger_grpsMap()
        {
            // Primary Key
            this.HasKey(t => t.trigger_group);

            // Properties
            this.Property(t => t.trigger_group)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("qrtz_paused_trigger_grps");
            this.Property(t => t.trigger_group).HasColumnName("trigger_group");
        }
    }
}
