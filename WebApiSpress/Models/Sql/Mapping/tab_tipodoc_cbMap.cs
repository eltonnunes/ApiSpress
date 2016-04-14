using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tab_tipodoc_cbMap : EntityTypeConfiguration<tab_tipodoc_cb>
    {
        public tab_tipodoc_cbMap()
        {
            // Primary Key
            this.HasKey(t => t.tipodoc);

            // Properties
            this.Property(t => t.tipodoc)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.descr_tipodoc)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("tab_tipodoc_cb");
            this.Property(t => t.tipodoc).HasColumnName("tipodoc");
            this.Property(t => t.descr_tipodoc).HasColumnName("descr_tipodoc");
        }
    }
}
