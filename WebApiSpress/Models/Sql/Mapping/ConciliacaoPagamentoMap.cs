using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class ConciliacaoPagamentoMap : EntityTypeConfiguration<ConciliacaoPagamento>
    {
        public ConciliacaoPagamentoMap()
        {
            // Primary Key
            this.HasKey(t => t.IdConciliacaoPagamento);

            // Properties
            this.Property(t => t.CNPJFilial)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.NsuHostTef)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.NsuSitef)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("ConciliacaoPagamentos", "cartao");
            this.Property(t => t.IdConciliacaoPagamento).HasColumnName("IdConciliacaoPagamento");
            this.Property(t => t.CNPJFilial).HasColumnName("CNPJFilial");
            this.Property(t => t.IdPdv).HasColumnName("IdPdv");
            this.Property(t => t.IdBandeira).HasColumnName("IdBandeira");
            this.Property(t => t.DtMovimentoPagto).HasColumnName("DtMovimentoPagto");
            this.Property(t => t.VlVenda).HasColumnName("VlVenda");
            this.Property(t => t.NsuHostTef).HasColumnName("NsuHostTef");
            this.Property(t => t.NumParcelas).HasColumnName("NumParcelas");
            this.Property(t => t.NsuSitef).HasColumnName("NsuSitef");

            // Relationships
            this.HasRequired(t => t.Bandeira)
                .WithMany(t => t.ConciliacaoPagamentos)
                .HasForeignKey(d => d.IdBandeira);
            this.HasRequired(t => t.PDV)
                .WithMany(t => t.ConciliacaoPagamentos)
                .HasForeignKey(d => d.IdPdv);

        }
    }
}
