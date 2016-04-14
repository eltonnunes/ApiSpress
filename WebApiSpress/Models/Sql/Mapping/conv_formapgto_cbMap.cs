using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class conv_formapgto_cbMap : EntityTypeConfiguration<conv_formapgto_cb>
    {
        public conv_formapgto_cbMap()
        {
            // Primary Key
            this.HasKey(t => t.formapagto_det);

            // Properties
            this.Property(t => t.formapagto_det)
                .IsRequired()
                .HasMaxLength(3);

            this.Property(t => t.desc_formapgto_det)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("conv_formapgto_cb");
            this.Property(t => t.formapagto_det).HasColumnName("formapagto_det");
            this.Property(t => t.desc_formapgto_det).HasColumnName("desc_formapgto_det");
            this.Property(t => t.formapagto).HasColumnName("formapagto");

            // Relationships
            this.HasOptional(t => t.tab_formapagto_cb)
                .WithMany(t => t.conv_formapgto_cb)
                .HasForeignKey(d => d.formapagto);

        }
    }
}
