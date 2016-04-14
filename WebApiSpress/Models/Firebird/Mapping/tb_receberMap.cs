using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Firebird.Mapping
{
    public class tb_receberMap : EntityTypeConfiguration<tb_receber>
    {
        public tb_receberMap()
        {
            // Properties
            this.Property(t => t.cod_recto);

            this.Property(t => t.loja);

            this.Property(t => t.Parcelas);

            // Table & Column Mappings
            this.ToTable("tb_receber");
            this.Property(t => t.cod_recto).HasColumnName("cod_recto");
            this.Property(t => t.loja).HasColumnName("loja");
            this.Property(t => t.Parcelas).HasColumnName("Parcelas");
        }
    }
}