using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class CargaMap : EntityTypeConfiguration<Carga>
    {
        public CargaMap()
        {
            // Primary Key
            this.HasKey(t => t.IdCargas);

            // Properties
            this.Property(t => t.CNPJFilial)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            // Table & Column Mappings
            this.ToTable("Cargas", "cartao");
            this.Property(t => t.IdCargas).HasColumnName("IdCargas");
            this.Property(t => t.CNPJFilial).HasColumnName("CNPJFilial");
            this.Property(t => t.IdPDV).HasColumnName("IdPDV");
            this.Property(t => t.DtTransacao).HasColumnName("DtTransacao");
            this.Property(t => t.DtImportacao).HasColumnName("DtImportacao");
            this.Property(t => t.FlRecarga).HasColumnName("FlRecarga");
            this.Property(t => t.IdUserRecarga).HasColumnName("IdUserRecarga");
            this.Property(t => t.DtRecarga).HasColumnName("DtRecarga");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.Cargas)
                .HasForeignKey(d => d.CNPJFilial);

        }
    }
}
