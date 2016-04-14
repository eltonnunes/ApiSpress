using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class cel_rede_autorizadoraMap : EntityTypeConfiguration<cel_rede_autorizadora>
    {
        public cel_rede_autorizadoraMap()
        {
            // Primary Key
            this.HasKey(t => t.cod_rede_autoriz);

            // Properties
            this.Property(t => t.cod_rede_autoriz)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.descr_rede_autoriz)
                .HasMaxLength(40);

            this.Property(t => t.cod_oper_se)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("cel_rede_autorizadora");
            this.Property(t => t.cod_rede_autoriz).HasColumnName("cod_rede_autoriz");
            this.Property(t => t.descr_rede_autoriz).HasColumnName("descr_rede_autoriz");
            this.Property(t => t.cod_oper_se).HasColumnName("cod_oper_se");
        }
    }
}
