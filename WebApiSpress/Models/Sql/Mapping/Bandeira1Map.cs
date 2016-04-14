using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class Bandeira1Map : EntityTypeConfiguration<Bandeira1>
    {
        public Bandeira1Map()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.descricaoBandeira)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.codBandeiraERP)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.sacado)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Bandeira", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.descricaoBandeira).HasColumnName("descricaoBandeira");
            this.Property(t => t.idGrupo).HasColumnName("idGrupo");
            this.Property(t => t.codBandeiraERP).HasColumnName("codBandeiraERP");
            this.Property(t => t.codBandeiraHostPagamento).HasColumnName("codBandeiraHostPagamento");
            this.Property(t => t.taxaAdministracao).HasColumnName("taxaAdministracao");
            this.Property(t => t.idTipoPagamento).HasColumnName("idTipoPagamento");
            this.Property(t => t.sacado).HasColumnName("sacado");
            this.Property(t => t.idAdquirente).HasColumnName("idAdquirente");

            // Relationships
            this.HasRequired(t => t.TipoPagamento)
                .WithMany(t => t.Bandeiras1)
                .HasForeignKey(d => d.idTipoPagamento);
            this.HasRequired(t => t.grupo_empresa)
                .WithMany(t => t.Bandeiras1)
                .HasForeignKey(d => d.idGrupo);

        }
    }
}
