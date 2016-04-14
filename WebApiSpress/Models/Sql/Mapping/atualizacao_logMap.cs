using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class atualizacao_logMap : EntityTypeConfiguration<atualizacao_log>
    {
        public atualizacao_logMap()
        {
            // Primary Key
            this.HasKey(t => new { t.data_atualizacao, t.fonte_atualizacao, t.msg_atualizacao });

            // Properties
            this.Property(t => t.fonte_atualizacao)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.msg_atualizacao)
                .IsRequired()
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("atualizacao_log");
            this.Property(t => t.data_atualizacao).HasColumnName("data_atualizacao");
            this.Property(t => t.fonte_atualizacao).HasColumnName("fonte_atualizacao");
            this.Property(t => t.msg_atualizacao).HasColumnName("msg_atualizacao");
        }
    }
}
