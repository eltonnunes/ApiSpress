using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class SodexoMap : EntityTypeConfiguration<Sodexo>
    {
        public SodexoMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.rede)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.descricao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.numCartao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.nsu)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.cdAutorizador)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.valorTotal)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            // Table & Column Mappings
            this.ToTable("Sodexo", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.dtaPagamento).HasColumnName("dtaPagamento");
            this.Property(t => t.dtaProcessamento).HasColumnName("dtaProcessamento");
            this.Property(t => t.dtaTransacao).HasColumnName("dtaTransacao");
            this.Property(t => t.rede).HasColumnName("rede");
            this.Property(t => t.descricao).HasColumnName("descricao");
            this.Property(t => t.numCartao).HasColumnName("numCartao");
            this.Property(t => t.nsu).HasColumnName("nsu");
            this.Property(t => t.cdAutorizador).HasColumnName("cdAutorizador");
            this.Property(t => t.valorTotal).HasColumnName("valorTotal");
            this.Property(t => t.cnpj).HasColumnName("cnpj");
            this.Property(t => t.idOperadora).HasColumnName("idOperadora");
            this.Property(t => t.idBandeira).HasColumnName("idBandeira");
            this.Property(t => t.dtaRecebimento).HasColumnName("dtaRecebimento");
            this.Property(t => t.idTerminalLogico).HasColumnName("idTerminalLogico");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.Sodexoes)
                .HasForeignKey(d => d.cnpj);
            this.HasRequired(t => t.BandeiraPos)
                .WithMany(t => t.Sodexoes)
                .HasForeignKey(d => d.idBandeira);
            this.HasRequired(t => t.Operadora)
                .WithMany(t => t.Sodexoes)
                .HasForeignKey(d => d.idOperadora);

        }
    }
}
