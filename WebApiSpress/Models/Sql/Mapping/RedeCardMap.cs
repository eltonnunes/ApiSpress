using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class RedeCardMap : EntityTypeConfiguration<RedeCard>
    {
        public RedeCardMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.nsu)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.numCartao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.estabelecimento)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.tipoCaptura)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.vendaCancelada)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.tipoVenda)
                .HasMaxLength(30);

            this.Property(t => t.codResumoVenda)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("RedeCard", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.nsu).HasColumnName("nsu");
            this.Property(t => t.numCartao).HasColumnName("numCartao");
            this.Property(t => t.dtaVenda).HasColumnName("dtaVenda");
            this.Property(t => t.valorBruto).HasColumnName("valorBruto");
            this.Property(t => t.totalParcelas).HasColumnName("totalParcelas");
            this.Property(t => t.estabelecimento).HasColumnName("estabelecimento");
            this.Property(t => t.tipoCaptura).HasColumnName("tipoCaptura");
            this.Property(t => t.vendaCancelada).HasColumnName("vendaCancelada");
            this.Property(t => t.cnpj).HasColumnName("cnpj");
            this.Property(t => t.idOperadora).HasColumnName("idOperadora");
            this.Property(t => t.idBandeira).HasColumnName("idBandeira");
            this.Property(t => t.dtaRecebimento).HasColumnName("dtaRecebimento");
            this.Property(t => t.idLogicoTerminal).HasColumnName("idLogicoTerminal");
            this.Property(t => t.tipoVenda).HasColumnName("tipoVenda");
            this.Property(t => t.taxaAdministracao).HasColumnName("taxaAdministracao");
            this.Property(t => t.codResumoVenda).HasColumnName("codResumoVenda");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.RedeCards)
                .HasForeignKey(d => d.cnpj);
            this.HasRequired(t => t.BandeiraPos)
                .WithMany(t => t.RedeCards)
                .HasForeignKey(d => d.idBandeira);
            this.HasRequired(t => t.Operadora)
                .WithMany(t => t.RedeCards)
                .HasForeignKey(d => d.idOperadora);

        }
    }
}
