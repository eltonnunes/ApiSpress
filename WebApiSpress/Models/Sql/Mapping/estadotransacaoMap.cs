using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class estadotransacaoMap : EntityTypeConfiguration<estadotransacao>
    {
        public estadotransacaoMap()
        {
            // Primary Key
            this.HasKey(t => t.estado_trn);

            // Properties
            this.Property(t => t.estado_trn)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.desc_estadotrn)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("estadotransacao");
            this.Property(t => t.estado_trn).HasColumnName("estado_trn");
            this.Property(t => t.desc_estadotrn).HasColumnName("desc_estadotrn");
        }
    }
}
