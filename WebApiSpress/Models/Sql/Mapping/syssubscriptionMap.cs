using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class syssubscriptionMap : EntityTypeConfiguration<syssubscription>
    {
        public syssubscriptionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.artid, t.srvid, t.dest_db, t.status, t.sync_type, t.login_name, t.subscription_type, t.timestamp, t.update_mode, t.loopback_detection, t.queued_reinit, t.nosync_type, t.srvname });

            // Properties
            this.Property(t => t.artid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.srvid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.dest_db)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.login_name)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.subscription_type)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.distribution_jobid)
                .IsFixedLength()
                .HasMaxLength(16);

            this.Property(t => t.timestamp)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            this.Property(t => t.srvname)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("syssubscriptions");
            this.Property(t => t.artid).HasColumnName("artid");
            this.Property(t => t.srvid).HasColumnName("srvid");
            this.Property(t => t.dest_db).HasColumnName("dest_db");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.sync_type).HasColumnName("sync_type");
            this.Property(t => t.login_name).HasColumnName("login_name");
            this.Property(t => t.subscription_type).HasColumnName("subscription_type");
            this.Property(t => t.distribution_jobid).HasColumnName("distribution_jobid");
            this.Property(t => t.timestamp).HasColumnName("timestamp");
            this.Property(t => t.update_mode).HasColumnName("update_mode");
            this.Property(t => t.loopback_detection).HasColumnName("loopback_detection");
            this.Property(t => t.queued_reinit).HasColumnName("queued_reinit");
            this.Property(t => t.nosync_type).HasColumnName("nosync_type");
            this.Property(t => t.srvname).HasColumnName("srvname");
        }
    }
}
