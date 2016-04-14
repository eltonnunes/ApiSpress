using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbRebimentoResumoMap : EntityTypeConfiguration<tbRebimentoResumo>
    {
        public tbRebimentoResumoMap()
        {
            // Primary Key
            this.HasKey(t => t.idRebimentoResumo);

            // Properties
            // Table & Column Mappings
            this.ToTable("tbRebimentoResumo", "card");
            this.Property(t => t.idRebimentoResumo).HasColumnName("idRebimentoResumo");
            this.Property(t => t.cdAdquirente).HasColumnName("cdAdquirente");
            this.Property(t => t.cdBandeira).HasColumnName("cdBandeira");
            this.Property(t => t.cdTipoProdutoTef).HasColumnName("cdTipoProdutoTef");
            this.Property(t => t.cdTerminal).HasColumnName("cdTerminal");
            this.Property(t => t.dtVenda).HasColumnName("dtVenda");
            this.Property(t => t.vlVendaBruto).HasColumnName("vlVendaBruto");
        }
    }
}