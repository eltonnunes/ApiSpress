using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbSituacaoRedeTefMap : EntityTypeConfiguration<tbSituacaoRedeTef>
    {
        public tbSituacaoRedeTefMap()
        {
            // Primary Key
            this.HasKey(t => t.cdSituacaoRedeTef);

            // Properties
            this.Property(t => t.cdSituacaoRedeTef)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.dsSituacao)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("tbSituacaoRedeTef", "card");
            this.Property(t => t.cdSituacaoRedeTef).HasColumnName("cdSituacaoRedeTef");
            this.Property(t => t.cdRedeTef).HasColumnName("cdRedeTef");
            this.Property(t => t.dsSituacao).HasColumnName("dsSituacao");
            this.Property(t => t.cdTipoSituacao).HasColumnName("cdTipoSituacao");
        }
    }
}
