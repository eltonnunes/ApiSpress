using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class GetNetSantanderMap : EntityTypeConfiguration<GetNetSantander>
    {
        public GetNetSantanderMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.bandeira)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.produto)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.descricaoTransacao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.numCartao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.numCv)
                .HasMaxLength(255);

            this.Property(t => t.numAutorizacao)
                .HasMaxLength(255);

            this.Property(t => t.cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            // Table & Column Mappings
            this.ToTable("GetNetSantander", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.bandeira).HasColumnName("bandeira");
            this.Property(t => t.produto).HasColumnName("produto");
            this.Property(t => t.descricaoTransacao).HasColumnName("descricaoTransacao");
            this.Property(t => t.dtaTransacao).HasColumnName("dtaTransacao");
            this.Property(t => t.hraTransacao).HasColumnName("hraTransacao");
            this.Property(t => t.dtahraTransacao).HasColumnName("dtahraTransacao");
            this.Property(t => t.numCartao).HasColumnName("numCartao");
            this.Property(t => t.numCv).HasColumnName("numCv");
            this.Property(t => t.numAutorizacao).HasColumnName("numAutorizacao");
            this.Property(t => t.valorTotalTransacao).HasColumnName("valorTotalTransacao");
            this.Property(t => t.totalParcelas).HasColumnName("totalParcelas");
            this.Property(t => t.cnpj).HasColumnName("cnpj");
            this.Property(t => t.idOperadora).HasColumnName("idOperadora");
            this.Property(t => t.idBandeira).HasColumnName("idBandeira");
            this.Property(t => t.dtaRecebimento).HasColumnName("dtaRecebimento");
            this.Property(t => t.idTerminalLogico).HasColumnName("idTerminalLogico");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.GetNetSantanders)
                .HasForeignKey(d => d.cnpj);
            this.HasRequired(t => t.BandeiraPos)
                .WithMany(t => t.GetNetSantanders)
                .HasForeignKey(d => d.idBandeira);
            this.HasRequired(t => t.Operadora)
                .WithMany(t => t.GetNetSantanders)
                .HasForeignKey(d => d.idOperadora);

        }
    }
}
