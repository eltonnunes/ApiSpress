using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class TicketCarMap : EntityTypeConfiguration<TicketCar>
    {
        public TicketCarMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.descricao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.tipoTransacao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.reembolso)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.numCartao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.numOS)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.mercadoria)
                .HasMaxLength(255);

            this.Property(t => t.qtde)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.empresa)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            // Table & Column Mappings
            this.ToTable("TicketCar", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.dtaTransacao).HasColumnName("dtaTransacao");
            this.Property(t => t.descricao).HasColumnName("descricao");
            this.Property(t => t.tipoTransacao).HasColumnName("tipoTransacao");
            this.Property(t => t.reembolso).HasColumnName("reembolso");
            this.Property(t => t.numCartao).HasColumnName("numCartao");
            this.Property(t => t.numOS).HasColumnName("numOS");
            this.Property(t => t.mercadoria).HasColumnName("mercadoria");
            this.Property(t => t.qtde).HasColumnName("qtde");
            this.Property(t => t.valorUnitario).HasColumnName("valorUnitario");
            this.Property(t => t.valorDesconto).HasColumnName("valorDesconto");
            this.Property(t => t.valorBruto).HasColumnName("valorBruto");
            this.Property(t => t.empresa).HasColumnName("empresa");
            this.Property(t => t.cnpj).HasColumnName("cnpj");
            this.Property(t => t.idOperadora).HasColumnName("idOperadora");
            this.Property(t => t.idBandeira).HasColumnName("idBandeira");
            this.Property(t => t.dtaRecebimento).HasColumnName("dtaRecebimento");
            this.Property(t => t.idTerminalLogico).HasColumnName("idTerminalLogico");

            // Relationships
            this.HasRequired(t => t.empresa1)
                .WithMany(t => t.TicketCars)
                .HasForeignKey(d => d.cnpj);
            this.HasRequired(t => t.BandeiraPos)
                .WithMany(t => t.TicketCars)
                .HasForeignKey(d => d.idBandeira);
            this.HasRequired(t => t.Operadora)
                .WithMany(t => t.TicketCars)
                .HasForeignKey(d => d.idOperadora);

        }
    }
}
