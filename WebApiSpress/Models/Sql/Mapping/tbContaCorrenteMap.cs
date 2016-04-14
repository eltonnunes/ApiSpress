using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbContaCorrenteMap : EntityTypeConfiguration<tbContaCorrente>
    {
        public tbContaCorrenteMap()
        {
            // Primary Key
            this.HasKey(t => t.cdContaCorrente);

            // Properties
            this.Property(t => t.nrCnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.cdBanco)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.nrAgencia)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.nrConta)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("tbContaCorrente", "card");
            this.Property(t => t.cdContaCorrente).HasColumnName("cdContaCorrente");
            this.Property(t => t.cdGrupo).HasColumnName("cdGrupo");
            this.Property(t => t.nrCnpj).HasColumnName("nrCnpj");
            this.Property(t => t.cdBanco).HasColumnName("cdBanco");
            this.Property(t => t.nrAgencia).HasColumnName("nrAgencia");
            this.Property(t => t.nrConta).HasColumnName("nrConta");
            this.Property(t => t.flAtivo).HasColumnName("flAtivo");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.tbContaCorrentes)
                .HasForeignKey(d => d.nrCnpj);
            this.HasRequired(t => t.grupo_empresa)
                .WithMany(t => t.tbContaCorrentes)
                .HasForeignKey(d => d.cdGrupo);

        }
    }
}