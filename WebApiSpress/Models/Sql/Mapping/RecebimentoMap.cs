using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class RecebimentoMap : EntityTypeConfiguration<WebApiSpress.Models.Sql.Recebimento>
    {
        public RecebimentoMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
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

            this.Property(t => t.codTituloERP)
                .HasMaxLength(255);

            this.Property(t => t.codVendaERP)
                .HasMaxLength(255);

            this.Property(t => t.codResumoVenda)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Recebimento", "pos");
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
            this.Property(t => t.codTituloERP).HasColumnName("codTituloERP");
            this.Property(t => t.codVendaERP).HasColumnName("codVendaERP");
            this.Property(t => t.codResumoVenda).HasColumnName("codResumoVenda");
            this.Property(t => t.numParcelaTotal).HasColumnName("numParcelaTotal");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.Recebimentoes)
                .HasForeignKey(d => d.cnpj);
            this.HasRequired(t => t.BandeiraPos)
                .WithMany(t => t.Recebimentoes)
                .HasForeignKey(d => d.idBandeira);
            this.HasRequired(t => t.TerminalLogico)
                .WithMany(t => t.Recebimentoes)
                .HasForeignKey(d => d.idLogicoTerminal);

        }
    }
}
