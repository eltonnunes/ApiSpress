using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class nivel_usuariosMap : EntityTypeConfiguration<nivel_usuarios>
    {
        public nivel_usuariosMap()
        {
            // Primary Key
            this.HasKey(t => t.nivel_usuario);

            // Properties
            this.Property(t => t.nivel_usuario)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.desc_nivel_usuario)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("nivel_usuarios");
            this.Property(t => t.nivel_usuario).HasColumnName("nivel_usuario");
            this.Property(t => t.desc_nivel_usuario).HasColumnName("desc_nivel_usuario");
        }
    }
}
