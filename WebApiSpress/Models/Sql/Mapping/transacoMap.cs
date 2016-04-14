using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class transacoMap : EntityTypeConfiguration<transaco>
    {
        public transacoMap()
        {
            // Primary Key
            this.HasKey(t => t.cod_trnweb);

            // Properties
            this.Property(t => t.cod_trnweb)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.descr_trn)
                .HasMaxLength(40);

            this.Property(t => t.descr_trn_abrev)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("transacoes");
            this.Property(t => t.cod_trnweb).HasColumnName("cod_trnweb");
            this.Property(t => t.descr_trn).HasColumnName("descr_trn");
            this.Property(t => t.descr_trn_abrev).HasColumnName("descr_trn_abrev");

            // Relationships
            this.HasMany(t => t.tipo_transacao)
                .WithMany(t => t.transacoes)
                .Map(m =>
                    {
                        m.ToTable("def_tipo_transacao");
                        m.MapLeftKey("cod_trnweb");
                        m.MapRightKey("tipo_id");
                    });


        }
    }
}
