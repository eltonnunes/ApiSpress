using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class BandeiraMap : EntityTypeConfiguration<Bandeira>
    {
        public BandeiraMap()
        {
            // Primary Key
            this.HasKey(t => t.IdBandeira);

            // Properties
            this.Property(t => t.DescricaoBandeira)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.CodBandeiraERP)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Sacado)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Bandeiras", "cartao");
            this.Property(t => t.IdBandeira).HasColumnName("IdBandeira");
            this.Property(t => t.DescricaoBandeira).HasColumnName("DescricaoBandeira");
            this.Property(t => t.IdGrupo).HasColumnName("IdGrupo");
            this.Property(t => t.CodBandeiraERP).HasColumnName("CodBandeiraERP");
            this.Property(t => t.CodBandeiraHostPagamento).HasColumnName("CodBandeiraHostPagamento");
            this.Property(t => t.TaxaAdministracao).HasColumnName("TaxaAdministracao");
            this.Property(t => t.IdTipoPagamento).HasColumnName("IdTipoPagamento");
            this.Property(t => t.Sacado).HasColumnName("Sacado");

            // Relationships
            this.HasRequired(t => t.grupo_empresa)
                .WithMany(t => t.Bandeiras)
                .HasForeignKey(d => d.IdGrupo);
            this.HasRequired(t => t.TipoPagamento)
                .WithMany(t => t.Bandeiras)
                .HasForeignKey(d => d.IdTipoPagamento);

        }
    }
}
