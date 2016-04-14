using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class NutricashMap : EntityTypeConfiguration<Nutricash>
    {
        public NutricashMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.cdAutorizador)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.status)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.numCartao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.credenciado)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            // Table & Column Mappings
            this.ToTable("Nutricash", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.cdAutorizador).HasColumnName("cdAutorizador");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.dtaHora).HasColumnName("dtaHora");
            this.Property(t => t.numCartao).HasColumnName("numCartao");
            this.Property(t => t.credenciado).HasColumnName("credenciado");
            this.Property(t => t.valor).HasColumnName("valor");
            this.Property(t => t.cnpj).HasColumnName("cnpj");
            this.Property(t => t.idOperadora).HasColumnName("idOperadora");
            this.Property(t => t.idBandeira).HasColumnName("idBandeira");
            this.Property(t => t.dtaRecebimento).HasColumnName("dtaRecebimento");
            this.Property(t => t.idTerminalLogico).HasColumnName("idTerminalLogico");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.Nutricashes)
                .HasForeignKey(d => d.cnpj);
            this.HasRequired(t => t.BandeiraPos)
                .WithMany(t => t.Nutricashes)
                .HasForeignKey(d => d.idBandeira);
            this.HasRequired(t => t.Operadora)
                .WithMany(t => t.Nutricashes)
                .HasForeignKey(d => d.idOperadora);

        }
    }
}
