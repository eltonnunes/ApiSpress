using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class qrtz_job_detailsMap : EntityTypeConfiguration<qrtz_job_details>
    {
        public qrtz_job_detailsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.job_name, t.job_group });

            // Properties
            this.Property(t => t.job_name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.job_group)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.description)
                .HasMaxLength(250);

            this.Property(t => t.job_class_name)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.is_durable)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.is_volatile)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.is_stateful)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.requests_recovery)
                .IsRequired()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("qrtz_job_details");
            this.Property(t => t.job_name).HasColumnName("job_name");
            this.Property(t => t.job_group).HasColumnName("job_group");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.job_class_name).HasColumnName("job_class_name");
            this.Property(t => t.is_durable).HasColumnName("is_durable");
            this.Property(t => t.is_volatile).HasColumnName("is_volatile");
            this.Property(t => t.is_stateful).HasColumnName("is_stateful");
            this.Property(t => t.requests_recovery).HasColumnName("requests_recovery");
            this.Property(t => t.job_data).HasColumnName("job_data");
        }
    }
}
