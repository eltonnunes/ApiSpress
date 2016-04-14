using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class sysarticleMap : EntityTypeConfiguration<sysarticle>
    {
        public sysarticleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.artid, t.dest_table, t.filter, t.name, t.objid, t.pubid, t.pre_creation_cmd, t.status, t.sync_objid, t.type, t.fire_triggers_on_snapshot });

            // Properties
            this.Property(t => t.artid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.creation_script)
                .HasMaxLength(255);

            this.Property(t => t.del_cmd)
                .HasMaxLength(255);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.dest_table)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.filter)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ins_cmd)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.objid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.pubid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.sync_objid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.upd_cmd)
                .HasMaxLength(255);

            this.Property(t => t.schema_option)
                .IsFixedLength()
                .HasMaxLength(8);

            this.Property(t => t.dest_owner)
                .HasMaxLength(128);

            this.Property(t => t.custom_script)
                .HasMaxLength(2048);

            // Table & Column Mappings
            this.ToTable("sysarticles");
            this.Property(t => t.artid).HasColumnName("artid");
            this.Property(t => t.creation_script).HasColumnName("creation_script");
            this.Property(t => t.del_cmd).HasColumnName("del_cmd");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.dest_table).HasColumnName("dest_table");
            this.Property(t => t.filter).HasColumnName("filter");
            this.Property(t => t.filter_clause).HasColumnName("filter_clause");
            this.Property(t => t.ins_cmd).HasColumnName("ins_cmd");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.objid).HasColumnName("objid");
            this.Property(t => t.pubid).HasColumnName("pubid");
            this.Property(t => t.pre_creation_cmd).HasColumnName("pre_creation_cmd");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.sync_objid).HasColumnName("sync_objid");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.upd_cmd).HasColumnName("upd_cmd");
            this.Property(t => t.schema_option).HasColumnName("schema_option");
            this.Property(t => t.dest_owner).HasColumnName("dest_owner");
            this.Property(t => t.ins_scripting_proc).HasColumnName("ins_scripting_proc");
            this.Property(t => t.del_scripting_proc).HasColumnName("del_scripting_proc");
            this.Property(t => t.upd_scripting_proc).HasColumnName("upd_scripting_proc");
            this.Property(t => t.custom_script).HasColumnName("custom_script");
            this.Property(t => t.fire_triggers_on_snapshot).HasColumnName("fire_triggers_on_snapshot");
        }
    }
}
