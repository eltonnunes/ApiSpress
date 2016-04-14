using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class estado_usuarioMap : EntityTypeConfiguration<estado_usuario>
    {
        public estado_usuarioMap()
        {
            // Primary Key
            this.HasKey(t => t.cod_estado);

            // Properties
            this.Property(t => t.cod_estado)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.desc_estado)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("estado_usuario");
            this.Property(t => t.cod_estado).HasColumnName("cod_estado");
            this.Property(t => t.desc_estado).HasColumnName("desc_estado");
        }
    }
}
