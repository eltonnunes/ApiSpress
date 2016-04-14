using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class TipoPagamentoMap : EntityTypeConfiguration<TipoPagamento>
    {
        public TipoPagamentoMap()
        {
            // Primary Key
            this.HasKey(t => t.IdTipoPagamento);

            // Properties
            this.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TipoPagamento", "cartao");
            this.Property(t => t.IdTipoPagamento).HasColumnName("IdTipoPagamento");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
        }
    }
}
