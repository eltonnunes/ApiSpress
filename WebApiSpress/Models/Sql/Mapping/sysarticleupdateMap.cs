using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class sysarticleupdateMap : EntityTypeConfiguration<sysarticleupdate>
    {
        public sysarticleupdateMap()
        {
            // Primary Key
            this.HasKey(t => new { t.artid, t.pubid, t.sync_ins_proc, t.sync_upd_proc, t.sync_del_proc, t.autogen, t.sync_upd_trig, t.identity_support });

            // Properties
            this.Property(t => t.artid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.pubid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.sync_ins_proc)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.sync_upd_proc)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.sync_del_proc)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.sync_upd_trig)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("sysarticleupdates");
            this.Property(t => t.artid).HasColumnName("artid");
            this.Property(t => t.pubid).HasColumnName("pubid");
            this.Property(t => t.sync_ins_proc).HasColumnName("sync_ins_proc");
            this.Property(t => t.sync_upd_proc).HasColumnName("sync_upd_proc");
            this.Property(t => t.sync_del_proc).HasColumnName("sync_del_proc");
            this.Property(t => t.autogen).HasColumnName("autogen");
            this.Property(t => t.sync_upd_trig).HasColumnName("sync_upd_trig");
            this.Property(t => t.conflict_tableid).HasColumnName("conflict_tableid");
            this.Property(t => t.ins_conflict_proc).HasColumnName("ins_conflict_proc");
            this.Property(t => t.identity_support).HasColumnName("identity_support");
        }
    }
}
