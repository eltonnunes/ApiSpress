using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class PDVMap : EntityTypeConfiguration<PDV>
    {
        public PDVMap()
        {
            // Primary Key
            this.HasKey(t => t.IdPDV);

            // Properties
            this.Property(t => t.CNPJjFilial)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.DecricaoPdv)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.CodPdvERP)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.CodPdvHostPagamento)
                .IsRequired()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("PDVs", "cartao");
            this.Property(t => t.IdPDV).HasColumnName("IdPDV");
            this.Property(t => t.CNPJjFilial).HasColumnName("CNPJjFilial");
            this.Property(t => t.DecricaoPdv).HasColumnName("DecricaoPdv");
            this.Property(t => t.CodPdvERP).HasColumnName("CodPdvERP");
            this.Property(t => t.CodPdvHostPagamento).HasColumnName("CodPdvHostPagamento");
            this.Property(t => t.cdGrupo).HasColumnName("cdGrupo");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.PDVs)
                .HasForeignKey(d => d.CNPJjFilial);

        }
    }
}
