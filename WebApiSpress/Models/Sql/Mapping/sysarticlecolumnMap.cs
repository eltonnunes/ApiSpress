using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class sysarticlecolumnMap : EntityTypeConfiguration<sysarticlecolumn>
    {
        public sysarticlecolumnMap()
        {
            // Primary Key
            this.HasKey(t => new { t.artid, t.colid });

            // Properties
            this.Property(t => t.artid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.colid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("sysarticlecolumns");
            this.Property(t => t.artid).HasColumnName("artid");
            this.Property(t => t.colid).HasColumnName("colid");
            this.Property(t => t.is_udt).HasColumnName("is_udt");
            this.Property(t => t.is_xml).HasColumnName("is_xml");
            this.Property(t => t.is_max).HasColumnName("is_max");
        }
    }
}
