using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class log_eventos_desc_eventosMap : EntityTypeConfiguration<log_eventos_desc_eventos>
    {
        public log_eventos_desc_eventosMap()
        {
            // Primary Key
            this.HasKey(t => t.cod_evento);

            // Properties
            this.Property(t => t.cod_evento)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.desc_evento)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("log_eventos_desc_eventos");
            this.Property(t => t.cod_evento).HasColumnName("cod_evento");
            this.Property(t => t.desc_evento).HasColumnName("desc_evento");
        }
    }
}
