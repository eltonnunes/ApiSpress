using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbEstadoTransacaoTefMap : EntityTypeConfiguration<tbEstadoTransacaoTef>
    {
        public tbEstadoTransacaoTefMap()
        {
            // Primary Key
            this.HasKey(t => t.cdEstadoTransacaoTef);

            // Properties
            this.Property(t => t.cdEstadoTransacaoTef)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.dsEstadoTransacaoTef)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("tbEstadoTransacaoTef", "card");
            this.Property(t => t.cdEstadoTransacaoTef).HasColumnName("cdEstadoTransacaoTef");
            this.Property(t => t.dsEstadoTransacaoTef).HasColumnName("dsEstadoTransacaoTef");
        }
    }
}
