using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tab_formapagto_cbMap : EntityTypeConfiguration<tab_formapagto_cb>
    {
        public tab_formapagto_cbMap()
        {
            // Primary Key
            this.HasKey(t => t.formapagto);

            // Properties
            this.Property(t => t.formapagto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.descr_formapagto)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("tab_formapagto_cb");
            this.Property(t => t.formapagto).HasColumnName("formapagto");
            this.Property(t => t.descr_formapagto).HasColumnName("descr_formapagto");
        }
    }
}
