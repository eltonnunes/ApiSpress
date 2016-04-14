using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class BaneseCardMap : EntityTypeConfiguration<BaneseCard>
    {
        public BaneseCardMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.operacao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.nsu)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.modalidade)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            // Table & Column Mappings
            this.ToTable("BaneseCard", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.operacao).HasColumnName("operacao");
            this.Property(t => t.dtaVenda).HasColumnName("dtaVenda");
            this.Property(t => t.nsu).HasColumnName("nsu");
            this.Property(t => t.modalidade).HasColumnName("modalidade");
            this.Property(t => t.totalParcelas).HasColumnName("totalParcelas");
            this.Property(t => t.valorBruto).HasColumnName("valorBruto");
            this.Property(t => t.valorLiquido).HasColumnName("valorLiquido");
            this.Property(t => t.cnpj).HasColumnName("cnpj");
            this.Property(t => t.idOperadora).HasColumnName("idOperadora");
            this.Property(t => t.idBandeira).HasColumnName("idBandeira");
            this.Property(t => t.dtaRecebimento).HasColumnName("dtaRecebimento");
            this.Property(t => t.idTerminalLogico).HasColumnName("idTerminalLogico");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.BaneseCards)
                .HasForeignKey(d => d.cnpj);
            this.HasRequired(t => t.BandeiraPos)
                .WithMany(t => t.BaneseCards)
                .HasForeignKey(d => d.idBandeira);
            this.HasRequired(t => t.Operadora)
                .WithMany(t => t.BaneseCards)
                .HasForeignKey(d => d.idOperadora);

        }
    }
}
