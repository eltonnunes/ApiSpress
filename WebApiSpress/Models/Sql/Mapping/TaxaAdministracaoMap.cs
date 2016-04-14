using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class TaxaAdministracaoMap : EntityTypeConfiguration<TaxaAdministracao>
    {
        public TaxaAdministracaoMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.plano)
                .HasMaxLength(255);

            this.Property(t => t.numBanco)
                .HasMaxLength(30);

            this.Property(t => t.numAgencia)
                .HasMaxLength(30);

            this.Property(t => t.numContaCorrente)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("TaxaAdministracao", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idAdquirente).HasColumnName("idAdquirente");
            this.Property(t => t.idBandeira).HasColumnName("idBandeira");
            this.Property(t => t.cnpj).HasColumnName("cnpj");
            this.Property(t => t.plano).HasColumnName("plano");
            this.Property(t => t.numParcela).HasColumnName("numParcela");
            this.Property(t => t.numBanco).HasColumnName("numBanco");
            this.Property(t => t.numAgencia).HasColumnName("numAgencia");
            this.Property(t => t.numContaCorrente).HasColumnName("numContaCorrente");
            this.Property(t => t.taxa).HasColumnName("taxa");
            this.Property(t => t.dtaAtualizacao).HasColumnName("dtaAtualizacao");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.TaxaAdministracaos)
                .HasForeignKey(d => d.cnpj);
            this.HasOptional(t => t.Adquirente)
                .WithMany(t => t.TaxaAdministracaos)
                .HasForeignKey(d => d.idAdquirente);
            this.HasRequired(t => t.BandeiraPos)
                .WithMany(t => t.TaxaAdministracaos)
                .HasForeignKey(d => d.idBandeira);

        }
    }
}
