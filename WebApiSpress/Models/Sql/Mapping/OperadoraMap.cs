using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class OperadoraMap : EntityTypeConfiguration<Operadora>
    {
        public OperadoraMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.nmOperadora)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Operadora", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.nmOperadora).HasColumnName("nmOperadora");
            this.Property(t => t.idGrupoEmpresa).HasColumnName("idGrupoEmpresa");

            // Relationships
            this.HasRequired(t => t.grupo_empresa)
                .WithMany(t => t.Operadoras)
                .HasForeignKey(d => d.idGrupoEmpresa);

        }
    }
}
