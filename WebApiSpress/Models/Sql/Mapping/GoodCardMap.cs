using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class GoodCardMap : EntityTypeConfiguration<GoodCard>
    {
        public GoodCardMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.lancamento)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.lote)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.numCartao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.redeCaptura)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("GoodCard", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.lancamento).HasColumnName("lancamento");
            this.Property(t => t.dtaHora).HasColumnName("dtaHora");
            this.Property(t => t.qtdTotalParcelas).HasColumnName("qtdTotalParcelas");
            this.Property(t => t.lote).HasColumnName("lote");
            this.Property(t => t.cnpj).HasColumnName("cnpj");
            this.Property(t => t.numCartao).HasColumnName("numCartao");
            this.Property(t => t.redeCaptura).HasColumnName("redeCaptura");
            this.Property(t => t.valorTransacao).HasColumnName("valorTransacao");
            this.Property(t => t.valorReembolso).HasColumnName("valorReembolso");
            this.Property(t => t.valorDescontado).HasColumnName("valorDescontado");
            this.Property(t => t.dtaRecebimento).HasColumnName("dtaRecebimento");
            this.Property(t => t.idOperadora).HasColumnName("idOperadora");
            this.Property(t => t.idBandeira).HasColumnName("idBandeira");
            this.Property(t => t.idTerminalLogico).HasColumnName("idTerminalLogico");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.GoodCards)
                .HasForeignKey(d => d.cnpj);
            this.HasRequired(t => t.BandeiraPos)
                .WithMany(t => t.GoodCards)
                .HasForeignKey(d => d.idBandeira);
            this.HasRequired(t => t.Operadora)
                .WithMany(t => t.GoodCards)
                .HasForeignKey(d => d.idOperadora);

        }
    }
}
