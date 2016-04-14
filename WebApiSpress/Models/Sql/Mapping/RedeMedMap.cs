using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class RedeMedMap : EntityTypeConfiguration<RedeMed>
    {
        public RedeMedMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.cdAutorizador)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.empresa)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.nome)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.numCartao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.parcela)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.cancelada)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            // Table & Column Mappings
            this.ToTable("RedeMed", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.cdAutorizador).HasColumnName("cdAutorizador");
            this.Property(t => t.empresa).HasColumnName("empresa");
            this.Property(t => t.nome).HasColumnName("nome");
            this.Property(t => t.data).HasColumnName("data");
            this.Property(t => t.numCartao).HasColumnName("numCartao");
            this.Property(t => t.valor).HasColumnName("valor");
            this.Property(t => t.parcela).HasColumnName("parcela");
            this.Property(t => t.cancelada).HasColumnName("cancelada");
            this.Property(t => t.cnpj).HasColumnName("cnpj");
            this.Property(t => t.idOperadora).HasColumnName("idOperadora");
            this.Property(t => t.idBandeira).HasColumnName("idBandeira");
            this.Property(t => t.dtaRecebimento).HasColumnName("dtaRecebimento");
            this.Property(t => t.idTerminalLogico).HasColumnName("idTerminalLogico");

            // Relationships
            this.HasRequired(t => t.empresa1)
                .WithMany(t => t.RedeMeds)
                .HasForeignKey(d => d.cnpj);
            this.HasRequired(t => t.BandeiraPos)
                .WithMany(t => t.RedeMeds)
                .HasForeignKey(d => d.idBandeira);
            this.HasRequired(t => t.Operadora)
                .WithMany(t => t.RedeMeds)
                .HasForeignKey(d => d.idOperadora);

        }
    }
}
