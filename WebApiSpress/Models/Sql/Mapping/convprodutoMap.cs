using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class convprodutoMap : EntityTypeConfiguration<convproduto>
    {
        public convprodutoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.cod_sit, t.operacaotef, t.mascara_bin, t.tam_cartao });

            // Properties
            this.Property(t => t.cod_sit)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.operacaotef)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.mascara_bin)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.tam_cartao)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("convproduto");
            this.Property(t => t.cod_sit).HasColumnName("cod_sit");
            this.Property(t => t.operacaotef).HasColumnName("operacaotef");
            this.Property(t => t.mascara_bin).HasColumnName("mascara_bin");
            this.Property(t => t.tam_cartao).HasColumnName("tam_cartao");
            this.Property(t => t.idt_produto).HasColumnName("idt_produto");
            this.Property(t => t.idt_produto_local).HasColumnName("idt_produto_local");

            // Relationships
            this.HasRequired(t => t.sitrede)
                .WithMany(t => t.convprodutoes)
                .HasForeignKey(d => d.cod_sit);
            this.HasRequired(t => t.produto)
                .WithMany(t => t.convprodutoes)
                .HasForeignKey(d => d.idt_produto);

        }
    }
}
