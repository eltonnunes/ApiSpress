using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class AmexMap : EntityTypeConfiguration<Amex>
    {
        public AmexMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.nsu)
                .HasMaxLength(255);

            this.Property(t => t.cdAutorizador)
                .HasMaxLength(255);

            this.Property(t => t.cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.numCartao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.numSubmissao)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Amex", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.dataRecebimento).HasColumnName("dataRecebimento");
            this.Property(t => t.dataVenda).HasColumnName("dataVenda");
            this.Property(t => t.nsu).HasColumnName("nsu");
            this.Property(t => t.cdAutorizador).HasColumnName("cdAutorizador");
            this.Property(t => t.cnpj).HasColumnName("cnpj");
            this.Property(t => t.numCartao).HasColumnName("numCartao");
            this.Property(t => t.totalParcelas).HasColumnName("totalParcelas");
            this.Property(t => t.valorTotal).HasColumnName("valorTotal");
            this.Property(t => t.numSubmissao).HasColumnName("numSubmissao");
            this.Property(t => t.idOperadora).HasColumnName("idOperadora");
            this.Property(t => t.idBandeira).HasColumnName("idBandeira");
            this.Property(t => t.idTerminalLogico).HasColumnName("idTerminalLogico");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.Amexes)
                .HasForeignKey(d => d.cnpj);
            this.HasRequired(t => t.BandeiraPos)
                .WithMany(t => t.Amexes)
                .HasForeignKey(d => d.idBandeira);
            this.HasRequired(t => t.Operadora)
                .WithMany(t => t.Amexes)
                .HasForeignKey(d => d.idOperadora);

        }
    }
}
