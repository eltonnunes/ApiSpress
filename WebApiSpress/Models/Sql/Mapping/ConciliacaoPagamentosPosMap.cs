using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class ConciliacaoPagamentosPosMap : EntityTypeConfiguration<ConciliacaoPagamentosPos>
    {
        public ConciliacaoPagamentosPosMap()
        {
            // Primary Key
            this.HasKey(t => t.IdConciliacaoPagamento);

            // Properties
            this.Property(t => t.nu_cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.CdAutorizador)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("ConciliacaoPagamentosPos", "pos");
            this.Property(t => t.IdConciliacaoPagamento).HasColumnName("IdConciliacaoPagamento");
            this.Property(t => t.nu_cnpj).HasColumnName("nu_cnpj");
            this.Property(t => t.IdOperadora).HasColumnName("IdOperadora");
            this.Property(t => t.DtMovimentoPagto).HasColumnName("DtMovimentoPagto");
            this.Property(t => t.VlVenda).HasColumnName("VlVenda");
            this.Property(t => t.CdAutorizador).HasColumnName("CdAutorizador");
            this.Property(t => t.NumParcela).HasColumnName("NumParcela");
            this.Property(t => t.TotalParcelas).HasColumnName("TotalParcelas");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.ConciliacaoPagamentosPos)
                .HasForeignKey(d => d.nu_cnpj);
            this.HasRequired(t => t.Operadora)
                .WithMany(t => t.ConciliacaoPagamentosPos)
                .HasForeignKey(d => d.IdOperadora);

        }
    }
}
