using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class FitCardMap : EntityTypeConfiguration<FitCard>
    {
        public FitCardMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.hora)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.combustivel)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            // Table & Column Mappings
            this.ToTable("FitCard", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.numero).HasColumnName("numero");
            this.Property(t => t.data).HasColumnName("data");
            this.Property(t => t.hora).HasColumnName("hora");
            this.Property(t => t.combustivel).HasColumnName("combustivel");
            this.Property(t => t.valorTotalLitros).HasColumnName("valorTotalLitros");
            this.Property(t => t.valor).HasColumnName("valor");
            this.Property(t => t.valorLitro).HasColumnName("valorLitro");
            this.Property(t => t.cnpj).HasColumnName("cnpj");
            this.Property(t => t.idOperadora).HasColumnName("idOperadora");
            this.Property(t => t.idBandeira).HasColumnName("idBandeira");
            this.Property(t => t.dtaRecebimento).HasColumnName("dtaRecebimento");
            this.Property(t => t.idTerminalLogico).HasColumnName("idTerminalLogico");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.FitCards)
                .HasForeignKey(d => d.cnpj);
            this.HasRequired(t => t.BandeiraPos)
                .WithMany(t => t.FitCards)
                .HasForeignKey(d => d.idBandeira);
            this.HasRequired(t => t.Operadora)
                .WithMany(t => t.FitCards)
                .HasForeignKey(d => d.idOperadora);

        }
    }
}
