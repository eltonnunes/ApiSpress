using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbNotaDaGenteMap : EntityTypeConfiguration<tbNotaDaGente>
    {
        public tbNotaDaGenteMap()
        {
            // Primary Key
            this.HasKey(t => new { t.cdLoja, t.nrPDV, t.dtMovimento });

            // Properties
            this.Property(t => t.cdLoja)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.nrPDV)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.dsObservacao)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("tbNotaDaGente");
            this.Property(t => t.cdLoja).HasColumnName("cdLoja");
            this.Property(t => t.nrPDV).HasColumnName("nrPDV");
            this.Property(t => t.dtMovimento).HasColumnName("dtMovimento");
            this.Property(t => t.tpStatus).HasColumnName("tpStatus");
            this.Property(t => t.nrProtocolo).HasColumnName("nrProtocolo");
            this.Property(t => t.dsObservacao).HasColumnName("dsObservacao");
            this.Property(t => t.dtEnvio).HasColumnName("dtEnvio");
            this.Property(t => t.dsArquivo).HasColumnName("dsArquivo");
        }
    }
}
