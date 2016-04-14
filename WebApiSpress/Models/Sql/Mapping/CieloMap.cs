using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class CieloMap : EntityTypeConfiguration<Cielo>
    {
        public CieloMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.descricao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.resumo)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.numCartao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.nsu)
                .HasMaxLength(255);

            this.Property(t => t.cdAutorizador)
                .HasMaxLength(255);

            this.Property(t => t.rejeitado)
                .IsRequired()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Cielo", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.dtaVenda).HasColumnName("dtaVenda");
            this.Property(t => t.dtaPrevistaPagto).HasColumnName("dtaPrevistaPagto");
            this.Property(t => t.descricao).HasColumnName("descricao");
            this.Property(t => t.resumo).HasColumnName("resumo");
            this.Property(t => t.cnpj).HasColumnName("cnpj");
            this.Property(t => t.numCartao).HasColumnName("numCartao");
            this.Property(t => t.nsu).HasColumnName("nsu");
            this.Property(t => t.cdAutorizador).HasColumnName("cdAutorizador");
            this.Property(t => t.valorTotal).HasColumnName("valorTotal");
            this.Property(t => t.valorBruto).HasColumnName("valorBruto");
            this.Property(t => t.rejeitado).HasColumnName("rejeitado");
            this.Property(t => t.valorSaque).HasColumnName("valorSaque");
            this.Property(t => t.idOperadora).HasColumnName("idOperadora");
            this.Property(t => t.idBandeira).HasColumnName("idBandeira");
            this.Property(t => t.dtaRecebimento).HasColumnName("dtaRecebimento");
            this.Property(t => t.idTerminalLogico).HasColumnName("idTerminalLogico");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.Cieloes)
                .HasForeignKey(d => d.cnpj);
            this.HasRequired(t => t.BandeiraPos)
                .WithMany(t => t.Cieloes)
                .HasForeignKey(d => d.idBandeira);
            this.HasRequired(t => t.Operadora)
                .WithMany(t => t.Cieloes)
                .HasForeignKey(d => d.idOperadora);

        }
    }
}
