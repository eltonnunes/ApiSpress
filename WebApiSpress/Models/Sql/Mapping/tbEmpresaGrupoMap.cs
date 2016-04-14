using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbEmpresaGrupoMap : EntityTypeConfiguration<tbEmpresaGrupo>
    {
        public tbEmpresaGrupoMap()
        {
            // Primary Key
            this.HasKey(t => t.cdEmpresaGrupo);

            // Properties
            this.Property(t => t.cdEmpresaGrupo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.dsEmpresaGrupo)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tbEmpresaGrupo", "admin");
            this.Property(t => t.cdEmpresaGrupo).HasColumnName("cdEmpresaGrupo");
            this.Property(t => t.dsEmpresaGrupo).HasColumnName("dsEmpresaGrupo");
            this.Property(t => t.dtCadastro).HasColumnName("dtCadastro");
            this.Property(t => t.flCardServices).HasColumnName("flCardServices");
            this.Property(t => t.flTaxServices).HasColumnName("flTaxServices");
            this.Property(t => t.flProinfo).HasColumnName("flProinfo");
            this.Property(t => t.cdVendedor).HasColumnName("cdVendedor");
            this.Property(t => t.flAtivo).HasColumnName("flAtivo");
        }
    }
}
