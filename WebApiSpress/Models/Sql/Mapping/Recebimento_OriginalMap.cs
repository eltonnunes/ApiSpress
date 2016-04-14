using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class Recebimento_OriginalMap : EntityTypeConfiguration<Recebimento_Original>
    {
        public Recebimento_OriginalMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.nsu)
                .HasMaxLength(255);

            this.Property(t => t.cdAutorizador)
                .HasMaxLength(255);

            this.Property(t => t.loteImportacao)
                .IsRequired()
                .HasMaxLength(35);

            // Table & Column Mappings
            this.ToTable("Recebimento_Original", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idBandeira).HasColumnName("idBandeira");
            this.Property(t => t.cnpj).HasColumnName("cnpj");
            this.Property(t => t.nsu).HasColumnName("nsu");
            this.Property(t => t.cdAutorizador).HasColumnName("cdAutorizador");
            this.Property(t => t.dtaVenda).HasColumnName("dtaVenda");
            this.Property(t => t.valorVendaBruta).HasColumnName("valorVendaBruta");
            this.Property(t => t.valorVendaLiquida).HasColumnName("valorVendaLiquida");
            this.Property(t => t.loteImportacao).HasColumnName("loteImportacao");
            this.Property(t => t.dtaRecebimento).HasColumnName("dtaRecebimento");
            this.Property(t => t.idLogicoTerminal).HasColumnName("idLogicoTerminal");
        }
    }
}
