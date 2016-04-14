using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class regionalMap : EntityTypeConfiguration<regional>
    {
        public regionalMap()
        {
            // Primary Key
            this.HasKey(t => t.cod_regional);

            // Properties
            this.Property(t => t.cod_regional)
                .IsRequired()
                .HasMaxLength(17);

            this.Property(t => t.descr_regional)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("regional");
            this.Property(t => t.cod_regional).HasColumnName("cod_regional");
            this.Property(t => t.descr_regional).HasColumnName("descr_regional");
        }
    }
}
