using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Firebird.Mapping
{
    public class tb_itens_rcMap : EntityTypeConfiguration<tb_itens_rc>
    {
        public tb_itens_rcMap()
        {
            // Properties
            this.Property(t => t.cod_item_rc);

            this.Property(t => t.cod_recto);

            this.Property(t => t.loja);

            this.Property(t => t.forma);

            this.Property(t => t.dt_vcto);

            this.Property(t => t.total);

            this.Property(t => t.parcela);

            this.Property(t => t.dt_recebimento);            

            // Table & Column Mappings
            this.ToTable("tb_itens_rc");
            this.Property(t => t.cod_item_rc).HasColumnName("cod_item_rc");
            this.Property(t => t.cod_recto).HasColumnName("cod_recto");
            this.Property(t => t.loja).HasColumnName("loja");
            this.Property(t => t.forma).HasColumnName("forma");
            this.Property(t => t.dt_vcto).HasColumnName("dt_vcto");
            this.Property(t => t.total).HasColumnName("total");
            this.Property(t => t.parcela).HasColumnName("parcela");
            this.Property(t => t.dt_recebimento).HasColumnName("dt_recebimento");
        }
    }
}
