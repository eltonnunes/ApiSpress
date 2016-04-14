using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Firebird.Mapping
{
    public class tb_vendasMap : EntityTypeConfiguration<tb_vendas>
    {
        public tb_vendasMap()
        {
            // Properties
            this.Property(t => t.cod_venda);

            this.Property(t => t.loja);
            this.Property(t => t.Dt_Venda);

            this.Property(t => t.Total);

            // Table & Column Mappings
            this.ToTable("tb_vendas");
            this.Property(t => t.cod_venda).HasColumnName("cod_venda");
            this.Property(t => t.loja).HasColumnName("loja");
            this.Property(t => t.Dt_Venda).HasColumnName("Dt_Venda");
            this.Property(t => t.Total).HasColumnName("Total");
        }
    }
}