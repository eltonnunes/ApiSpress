using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class OmniMap : EntityTypeConfiguration<Omni>
    {
        public OmniMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.descricao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.produto)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.numCpf)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.numCartao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.metodo)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.situacao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.cdAutorizacao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.usuario)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            // Table & Column Mappings
            this.ToTable("Omni", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.dtaTransacao).HasColumnName("dtaTransacao");
            this.Property(t => t.descricao).HasColumnName("descricao");
            this.Property(t => t.produto).HasColumnName("produto");
            this.Property(t => t.numCpf).HasColumnName("numCpf");
            this.Property(t => t.numCartao).HasColumnName("numCartao");
            this.Property(t => t.valorTotal).HasColumnName("valorTotal");
            this.Property(t => t.metodo).HasColumnName("metodo");
            this.Property(t => t.situacao).HasColumnName("situacao");
            this.Property(t => t.cdAutorizacao).HasColumnName("cdAutorizacao");
            this.Property(t => t.usuario).HasColumnName("usuario");
            this.Property(t => t.cnpj).HasColumnName("cnpj");
            this.Property(t => t.idOperadora).HasColumnName("idOperadora");
            this.Property(t => t.idBandeira).HasColumnName("idBandeira");
            this.Property(t => t.dtaRecebimento).HasColumnName("dtaRecebimento");
            this.Property(t => t.idTerminalLogico).HasColumnName("idTerminalLogico");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.Omnis)
                .HasForeignKey(d => d.cnpj);
            this.HasRequired(t => t.BandeiraPos)
                .WithMany(t => t.Omnis)
                .HasForeignKey(d => d.idBandeira);
            this.HasRequired(t => t.Operadora)
                .WithMany(t => t.Omnis)
                .HasForeignKey(d => d.idOperadora);

        }
    }
}
