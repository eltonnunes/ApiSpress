using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class ufMap : EntityTypeConfiguration<uf>
    {
        public ufMap()
        {
            // Primary Key
            this.HasKey(t => t.cod_uf);

            // Properties
            this.Property(t => t.cod_uf)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.descr_uf)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("uf");
            this.Property(t => t.cod_uf).HasColumnName("cod_uf");
            this.Property(t => t.descr_uf).HasColumnName("descr_uf");
        }
    }
}
