using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class log_eventosMap : EntityTypeConfiguration<log_eventos>
    {
        public log_eventosMap()
        {
            // Primary Key
            this.HasKey(t => t.id_log);

            // Properties
            this.Property(t => t.id_log)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.cod_evento)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.cod_origem)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.cod_usuario)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.aplicacao)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("log_eventos");
            this.Property(t => t.id_log).HasColumnName("id_log");
            this.Property(t => t.cod_evento).HasColumnName("cod_evento");
            this.Property(t => t.datahora).HasColumnName("datahora");
            this.Property(t => t.cod_origem).HasColumnName("cod_origem");
            this.Property(t => t.cod_usuario).HasColumnName("cod_usuario");
            this.Property(t => t.se_cliente).HasColumnName("se_cliente");
            this.Property(t => t.id_schema).HasColumnName("id_schema");
            this.Property(t => t.aplicacao).HasColumnName("aplicacao");

            // Relationships
            this.HasRequired(t => t.log_eventos_desc_eventos)
                .WithMany(t => t.log_eventos)
                .HasForeignKey(d => d.cod_evento);
            this.HasRequired(t => t.log_eventos_desc_origem)
                .WithMany(t => t.log_eventos)
                .HasForeignKey(d => d.cod_origem);

        }
    }
}
