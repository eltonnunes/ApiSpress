using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class qrtz_job_listenersMap : EntityTypeConfiguration<qrtz_job_listeners>
    {
        public qrtz_job_listenersMap()
        {
            // Primary Key
            this.HasKey(t => new { t.job_name, t.job_group, t.job_listener });

            // Properties
            this.Property(t => t.job_name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.job_group)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.job_listener)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("qrtz_job_listeners");
            this.Property(t => t.job_name).HasColumnName("job_name");
            this.Property(t => t.job_group).HasColumnName("job_group");
            this.Property(t => t.job_listener).HasColumnName("job_listener");

            // Relationships
            this.HasRequired(t => t.qrtz_job_details)
                .WithMany(t => t.qrtz_job_listeners)
                .HasForeignKey(d => new { d.job_name, d.job_group });

        }
    }
}
