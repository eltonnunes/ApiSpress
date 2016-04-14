using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbNewsGrupoMap : EntityTypeConfiguration<tbNewsGrupos>
    {
        public tbNewsGrupoMap()
        {
            // Primary Key
            this.HasKey(t => t.cdNewsGrupo);

            // Properties
            this.Property(t => t.cdNewsGrupo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.dsNewsGrupo)
                .IsRequired()
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("tbNewsGrupos", "admin");
            this.Property(t => t.cdNewsGrupo).HasColumnName("cdNewsGrupo");
            this.Property(t => t.cdEmpresaGrupo).HasColumnName("cdEmpresaGrupo");
            this.Property(t => t.dsNewsGrupo).HasColumnName("dsNewsGrupo");

            // Relationships
            this.HasMany(t => t.webpages_Users)
                .WithMany(t => t.tbNewsGrupos)
                .Map(m =>
                {
                    m.ToTable("tbAssinante", "admin");
                    m.MapLeftKey("cdNewsGrupo");
                    m.MapRightKey("cdUser");
                });


        }
    }
}