using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tipoprodutoMap : EntityTypeConfiguration<tipoproduto>
    {
        public tipoprodutoMap()
        {
            // Primary Key
            this.HasKey(t => t.idt_tipoprd);

            // Properties
            this.Property(t => t.idt_tipoprd)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.descr_prd)
                .HasMaxLength(40);

            this.Property(t => t.exibe)
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("tipoproduto");
            this.Property(t => t.idt_tipoprd).HasColumnName("idt_tipoprd");
            this.Property(t => t.descr_prd).HasColumnName("descr_prd");
            this.Property(t => t.exibe).HasColumnName("exibe");
        }
    }
}
