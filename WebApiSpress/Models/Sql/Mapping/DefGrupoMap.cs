using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class DefGrupoMap : EntityTypeConfiguration<DefGrupo>
    {
        public DefGrupoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Cod_Grupo, t.CodLojaSitef });

            // Properties
            this.Property(t => t.Cod_Grupo)
                .IsRequired()
                .HasMaxLength(17);

            this.Property(t => t.CodLojaSitef)
                .IsRequired()
                .HasMaxLength(17);

            // Table & Column Mappings
            this.ToTable("DefGrupo");
            this.Property(t => t.Cod_Grupo).HasColumnName("Cod_Grupo");
            this.Property(t => t.CodLojaSitef).HasColumnName("CodLojaSitef");
        }
    }
}
