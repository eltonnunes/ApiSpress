using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbTransacaoTefMap : EntityTypeConfiguration<tbTransacaoTef>
    {
        public tbTransacaoTefMap()
        {
            // Primary Key
            this.HasKey(t => t.cdTransacaoTef);

            // Properties
            this.Property(t => t.cdTransacaoTef)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.dsTransacaoTef)
                .HasMaxLength(40);

            this.Property(t => t.dsAbreviadaTransacaoTef)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("tbTransacaoTef", "card");
            this.Property(t => t.cdTransacaoTef).HasColumnName("cdTransacaoTef");
            this.Property(t => t.dsTransacaoTef).HasColumnName("dsTransacaoTef");
            this.Property(t => t.dsAbreviadaTransacaoTef).HasColumnName("dsAbreviadaTransacaoTef");
        }
    }
}
