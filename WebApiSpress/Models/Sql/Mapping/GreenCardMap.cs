using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class GreenCardMap : EntityTypeConfiguration<GreenCard>
    {
        public GreenCardMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.cdAutorizador)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("GreenCard", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.dtaCompra).HasColumnName("dtaCompra");
            this.Property(t => t.dtaVencimento).HasColumnName("dtaVencimento");
            this.Property(t => t.cnpj).HasColumnName("cnpj");
            this.Property(t => t.cdAutorizador).HasColumnName("cdAutorizador");
            this.Property(t => t.valorTransacao).HasColumnName("valorTransacao");
            this.Property(t => t.dtaRecebimento).HasColumnName("dtaRecebimento");
            this.Property(t => t.idOperadora).HasColumnName("idOperadora");
            this.Property(t => t.idBandeira).HasColumnName("idBandeira");
            this.Property(t => t.idTerminalLogico).HasColumnName("idTerminalLogico");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.GreenCards)
                .HasForeignKey(d => d.cnpj);
            this.HasRequired(t => t.BandeiraPos)
                .WithMany(t => t.GreenCards)
                .HasForeignKey(d => d.idBandeira);
            this.HasRequired(t => t.Operadora)
                .WithMany(t => t.GreenCards)
                .HasForeignKey(d => d.idOperadora);

        }
    }
}
