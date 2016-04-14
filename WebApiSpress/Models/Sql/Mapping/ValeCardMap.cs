using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class ValeCardMap : EntityTypeConfiguration<ValeCard>
    {
        public ValeCardMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.descricao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.comprador)
                .HasMaxLength(255);

            this.Property(t => t.cd_autorizador)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.parcelaTotal)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.terminal)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("ValeCard", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.descricao).HasColumnName("descricao");
            this.Property(t => t.comprador).HasColumnName("comprador");
            this.Property(t => t.cd_autorizador).HasColumnName("cd_autorizador");
            this.Property(t => t.data).HasColumnName("data");
            this.Property(t => t.valor).HasColumnName("valor");
            this.Property(t => t.cnpj).HasColumnName("cnpj");
            this.Property(t => t.parcelaTotal).HasColumnName("parcelaTotal");
            this.Property(t => t.terminal).HasColumnName("terminal");
            this.Property(t => t.idOperadora).HasColumnName("idOperadora");
            this.Property(t => t.idBandeira).HasColumnName("idBandeira");
            this.Property(t => t.data_recebimento).HasColumnName("data_recebimento");
            this.Property(t => t.idTerminalLogico).HasColumnName("idTerminalLogico");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.ValeCards)
                .HasForeignKey(d => d.cnpj);
            this.HasRequired(t => t.BandeiraPos)
                .WithMany(t => t.ValeCards)
                .HasForeignKey(d => d.idBandeira);
            this.HasRequired(t => t.Operadora)
                .WithMany(t => t.ValeCards)
                .HasForeignKey(d => d.idOperadora);

        }
    }
}
