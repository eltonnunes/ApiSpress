using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class PoliCardMap : EntityTypeConfiguration<PoliCard>
    {
        public PoliCardMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.produto)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.usuario)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.cd_autorizador)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.tipo)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.rede)
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("PoliCard", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.data_transacao).HasColumnName("data_transacao");
            this.Property(t => t.produto).HasColumnName("produto");
            this.Property(t => t.cnpj).HasColumnName("cnpj");
            this.Property(t => t.prevRepasse).HasColumnName("prevRepasse");
            this.Property(t => t.usuario).HasColumnName("usuario");
            this.Property(t => t.cd_autorizador).HasColumnName("cd_autorizador");
            this.Property(t => t.tipo).HasColumnName("tipo");
            this.Property(t => t.valorCredito).HasColumnName("valorCredito");
            this.Property(t => t.valorDebito).HasColumnName("valorDebito");
            this.Property(t => t.Saldo).HasColumnName("Saldo");
            this.Property(t => t.rede).HasColumnName("rede");
            this.Property(t => t.idOperadora).HasColumnName("idOperadora");
            this.Property(t => t.idBandeira).HasColumnName("idBandeira");
            this.Property(t => t.data_recebimento).HasColumnName("data_recebimento");
            this.Property(t => t.idTerminalLogico).HasColumnName("idTerminalLogico");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.PoliCards)
                .HasForeignKey(d => d.cnpj);
            this.HasRequired(t => t.BandeiraPos)
                .WithMany(t => t.PoliCards)
                .HasForeignKey(d => d.idBandeira);
            this.HasRequired(t => t.Operadora)
                .WithMany(t => t.PoliCards)
                .HasForeignKey(d => d.idOperadora);

        }
    }
}
