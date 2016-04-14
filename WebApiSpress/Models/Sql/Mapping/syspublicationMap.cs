using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class syspublicationMap : EntityTypeConfiguration<syspublication>
    {
        public syspublicationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.name, t.pubid, t.repl_freq, t.status, t.sync_method, t.independent_agent, t.immediate_sync, t.enabled_for_internet, t.allow_push, t.allow_pull, t.allow_anonymous, t.immediate_sync_ready, t.allow_sync_tran, t.autogen_sync_procs, t.allow_queued_tran, t.snapshot_in_defaultfolder, t.compress_snapshot, t.ftp_port, t.allow_dts, t.allow_subscription_copy, t.backward_comp_level, t.allow_initialize_from_backup, t.options });

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.pubid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.snapshot_jobid)
                .IsFixedLength()
                .HasMaxLength(16);

            this.Property(t => t.alt_snapshot_folder)
                .HasMaxLength(255);

            this.Property(t => t.pre_snapshot_script)
                .HasMaxLength(255);

            this.Property(t => t.post_snapshot_script)
                .HasMaxLength(255);

            this.Property(t => t.ftp_address)
                .HasMaxLength(128);

            this.Property(t => t.ftp_port)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ftp_subdirectory)
                .HasMaxLength(255);

            this.Property(t => t.ftp_login)
                .HasMaxLength(128);

            this.Property(t => t.ftp_password)
                .HasMaxLength(524);

            this.Property(t => t.ad_guidname)
                .HasMaxLength(128);

            this.Property(t => t.backward_comp_level)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.min_autonosync_lsn)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.options)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("syspublications");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.pubid).HasColumnName("pubid");
            this.Property(t => t.repl_freq).HasColumnName("repl_freq");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.sync_method).HasColumnName("sync_method");
            this.Property(t => t.snapshot_jobid).HasColumnName("snapshot_jobid");
            this.Property(t => t.independent_agent).HasColumnName("independent_agent");
            this.Property(t => t.immediate_sync).HasColumnName("immediate_sync");
            this.Property(t => t.enabled_for_internet).HasColumnName("enabled_for_internet");
            this.Property(t => t.allow_push).HasColumnName("allow_push");
            this.Property(t => t.allow_pull).HasColumnName("allow_pull");
            this.Property(t => t.allow_anonymous).HasColumnName("allow_anonymous");
            this.Property(t => t.immediate_sync_ready).HasColumnName("immediate_sync_ready");
            this.Property(t => t.allow_sync_tran).HasColumnName("allow_sync_tran");
            this.Property(t => t.autogen_sync_procs).HasColumnName("autogen_sync_procs");
            this.Property(t => t.retention).HasColumnName("retention");
            this.Property(t => t.allow_queued_tran).HasColumnName("allow_queued_tran");
            this.Property(t => t.snapshot_in_defaultfolder).HasColumnName("snapshot_in_defaultfolder");
            this.Property(t => t.alt_snapshot_folder).HasColumnName("alt_snapshot_folder");
            this.Property(t => t.pre_snapshot_script).HasColumnName("pre_snapshot_script");
            this.Property(t => t.post_snapshot_script).HasColumnName("post_snapshot_script");
            this.Property(t => t.compress_snapshot).HasColumnName("compress_snapshot");
            this.Property(t => t.ftp_address).HasColumnName("ftp_address");
            this.Property(t => t.ftp_port).HasColumnName("ftp_port");
            this.Property(t => t.ftp_subdirectory).HasColumnName("ftp_subdirectory");
            this.Property(t => t.ftp_login).HasColumnName("ftp_login");
            this.Property(t => t.ftp_password).HasColumnName("ftp_password");
            this.Property(t => t.allow_dts).HasColumnName("allow_dts");
            this.Property(t => t.allow_subscription_copy).HasColumnName("allow_subscription_copy");
            this.Property(t => t.centralized_conflicts).HasColumnName("centralized_conflicts");
            this.Property(t => t.conflict_retention).HasColumnName("conflict_retention");
            this.Property(t => t.conflict_policy).HasColumnName("conflict_policy");
            this.Property(t => t.queue_type).HasColumnName("queue_type");
            this.Property(t => t.ad_guidname).HasColumnName("ad_guidname");
            this.Property(t => t.backward_comp_level).HasColumnName("backward_comp_level");
            this.Property(t => t.allow_initialize_from_backup).HasColumnName("allow_initialize_from_backup");
            this.Property(t => t.min_autonosync_lsn).HasColumnName("min_autonosync_lsn");
            this.Property(t => t.replicate_ddl).HasColumnName("replicate_ddl");
            this.Property(t => t.options).HasColumnName("options");
        }
    }
}
