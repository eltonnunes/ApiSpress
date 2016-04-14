using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class ConciliacaoVendaMap : EntityTypeConfiguration<ConciliacaoVenda>
    {
        public ConciliacaoVendaMap()
        {
            // Primary Key
            this.HasKey(t => t.IdConciliacaoVenda);

            // Properties
            this.Property(t => t.CNPJFilial)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.NumeroTitulo)
                .HasMaxLength(50);

            this.Property(t => t.NsuHostTef)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("ConciliacaoVendas", "cartao");
            this.Property(t => t.IdConciliacaoVenda).HasColumnName("IdConciliacaoVenda");
            this.Property(t => t.CNPJFilial).HasColumnName("CNPJFilial");
            this.Property(t => t.IdPdv).HasColumnName("IdPdv");
            this.Property(t => t.IdBandeira).HasColumnName("IdBandeira");
            this.Property(t => t.NumeroTitulo).HasColumnName("NumeroTitulo");
            this.Property(t => t.DtMovimentoVenda).HasColumnName("DtMovimentoVenda");
            this.Property(t => t.VlVenda).HasColumnName("VlVenda");
            this.Property(t => t.NsuHostTef).HasColumnName("NsuHostTef");
            this.Property(t => t.QuantidadeParcelas).HasColumnName("QuantidadeParcelas");
            this.Property(t => t.NumParcelas).HasColumnName("NumParcelas");

            // Relationships
            this.HasRequired(t => t.Bandeira)
                .WithMany(t => t.ConciliacaoVendas)
                .HasForeignKey(d => d.IdBandeira);
            this.HasRequired(t => t.PDV)
                .WithMany(t => t.ConciliacaoVendas)
                .HasForeignKey(d => d.IdPdv);

        }
    }
}
