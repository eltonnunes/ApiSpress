using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class log_eventos_desc_origemMap : EntityTypeConfiguration<log_eventos_desc_origem>
    {
        public log_eventos_desc_origemMap()
        {
            // Primary Key
            this.HasKey(t => t.cod_origem);

            // Properties
            this.Property(t => t.cod_origem)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.desc_origem)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("log_eventos_desc_origem");
            this.Property(t => t.cod_origem).HasColumnName("cod_origem");
            this.Property(t => t.desc_origem).HasColumnName("desc_origem");
        }
    }
}
