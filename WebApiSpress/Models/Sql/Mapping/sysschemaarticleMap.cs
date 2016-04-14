using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class sysschemaarticleMap : EntityTypeConfiguration<sysschemaarticle>
    {
        public sysschemaarticleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.artid, t.dest_object, t.name, t.objid, t.pubid, t.pre_creation_cmd, t.status, t.type });

            // Properties
            this.Property(t => t.artid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.creation_script)
                .HasMaxLength(255);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.dest_object)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.objid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.pubid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.status)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.schema_option)
                .IsFixedLength()
                .HasMaxLength(8);

            this.Property(t => t.dest_owner)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("sysschemaarticles");
            this.Property(t => t.artid).HasColumnName("artid");
            this.Property(t => t.creation_script).HasColumnName("creation_script");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.dest_object).HasColumnName("dest_object");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.objid).HasColumnName("objid");
            this.Property(t => t.pubid).HasColumnName("pubid");
            this.Property(t => t.pre_creation_cmd).HasColumnName("pre_creation_cmd");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.schema_option).HasColumnName("schema_option");
            this.Property(t => t.dest_owner).HasColumnName("dest_owner");
        }
    }
}
