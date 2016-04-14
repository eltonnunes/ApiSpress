using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class GrupoMap : EntityTypeConfiguration<Grupo>
    {
        public GrupoMap()
        {
            // Primary Key
            this.HasKey(t => t.Cod_Grupo);

            // Properties
            this.Property(t => t.Cod_Grupo)
                .IsRequired()
                .HasMaxLength(17);

            this.Property(t => t.Descr_Grupo)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("Grupo");
            this.Property(t => t.Cod_Grupo).HasColumnName("Cod_Grupo");
            this.Property(t => t.Descr_Grupo).HasColumnName("Descr_Grupo");
        }
    }
}
