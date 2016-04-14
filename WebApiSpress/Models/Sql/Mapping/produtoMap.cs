using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class produtoMap : EntityTypeConfiguration<produto>
    {
        public produtoMap()
        {
            // Primary Key
            this.HasKey(t => t.idt_produto);

            // Properties
            this.Property(t => t.idt_produto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.descr_produto)
                .HasMaxLength(40);

            this.Property(t => t.exibe)
                .HasMaxLength(1);

            this.Property(t => t.selbandeira)
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("produtos");
            this.Property(t => t.idt_produto).HasColumnName("idt_produto");
            this.Property(t => t.idt_tipoprd).HasColumnName("idt_tipoprd");
            this.Property(t => t.descr_produto).HasColumnName("descr_produto");
            this.Property(t => t.exibe).HasColumnName("exibe");
            this.Property(t => t.selbandeira).HasColumnName("selbandeira");

            // Relationships
            this.HasRequired(t => t.tipoproduto)
                .WithMany(t => t.produtos)
                .HasForeignKey(d => d.idt_tipoprd);

        }
    }
}
