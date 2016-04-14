using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tab_cbMap : EntityTypeConfiguration<tab_cb>
    {
        public tab_cbMap()
        {
            // Primary Key
            this.HasKey(t => t.cod_sit);

            // Properties
            this.Property(t => t.cod_sit)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.descr_cb)
                .HasMaxLength(40);

            this.Property(t => t.id_cb)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.exibe)
                .HasMaxLength(1);

            this.Property(t => t.descr_cb_abrev)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("tab_cb");
            this.Property(t => t.cod_sit).HasColumnName("cod_sit");
            this.Property(t => t.descr_cb).HasColumnName("descr_cb");
            this.Property(t => t.id_cb).HasColumnName("id_cb");
            this.Property(t => t.exibe).HasColumnName("exibe");
            this.Property(t => t.descr_cb_abrev).HasColumnName("descr_cb_abrev");
        }
    }
}
