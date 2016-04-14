using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class log_eventos_dadosMap : EntityTypeConfiguration<log_eventos_dados>
    {
        public log_eventos_dadosMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id_log, t.sequencia });

            // Properties
            this.Property(t => t.id_log)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.sequencia)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.operacao)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.sessao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.param)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.valor)
                .IsRequired()
                .HasMaxLength(3000);

            this.Property(t => t.valor_ant)
                .HasMaxLength(3000);

            // Table & Column Mappings
            this.ToTable("log_eventos_dados");
            this.Property(t => t.id_log).HasColumnName("id_log");
            this.Property(t => t.sequencia).HasColumnName("sequencia");
            this.Property(t => t.operacao).HasColumnName("operacao");
            this.Property(t => t.sessao).HasColumnName("sessao");
            this.Property(t => t.param).HasColumnName("param");
            this.Property(t => t.valor).HasColumnName("valor");
            this.Property(t => t.valor_ant).HasColumnName("valor_ant");

            // Relationships
            this.HasRequired(t => t.log_eventos)
                .WithMany(t => t.log_eventos_dados)
                .HasForeignKey(d => d.id_log);

        }
    }
}
