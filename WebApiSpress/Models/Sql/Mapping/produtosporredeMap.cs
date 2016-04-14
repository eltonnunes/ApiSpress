using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class produtosporredeMap : EntityTypeConfiguration<produtosporrede>
    {
        public produtosporredeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.idt_rede, t.idt_produto });

            // Properties
            this.Property(t => t.idt_rede)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idt_produto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.exibe)
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("produtosporrede");
            this.Property(t => t.idt_rede).HasColumnName("idt_rede");
            this.Property(t => t.idt_produto).HasColumnName("idt_produto");
            this.Property(t => t.exibe).HasColumnName("exibe");

            // Relationships
            this.HasRequired(t => t.produto)
                .WithMany(t => t.produtosporredes)
                .HasForeignKey(d => d.idt_produto);
            this.HasRequired(t => t.rede)
                .WithMany(t => t.produtosporredes)
                .HasForeignKey(d => d.idt_rede);

        }
    }
}
