using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class defregionalMap : EntityTypeConfiguration<defregional>
    {
        public defregionalMap()
        {
            // Primary Key
            this.HasKey(t => new { t.cod_regional, t.cod_grupo });

            // Properties
            this.Property(t => t.cod_regional)
                .IsRequired()
                .HasMaxLength(17);

            this.Property(t => t.cod_grupo)
                .IsRequired()
                .HasMaxLength(17);

            // Table & Column Mappings
            this.ToTable("defregional");
            this.Property(t => t.cod_regional).HasColumnName("cod_regional");
            this.Property(t => t.cod_grupo).HasColumnName("cod_grupo");
        }
    }
}
