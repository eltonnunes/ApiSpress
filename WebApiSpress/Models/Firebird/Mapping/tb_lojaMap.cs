using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Firebird.Mapping
{
    public class tb_lojaMap : EntityTypeConfiguration<tb_loja>
    {
        public tb_lojaMap()
        {
            // Properties
            this.Property(t => t.cod_loja);

            this.Property(t => t.loja);

            this.Property(t => t.CNPJ);

            // Table & Column Mappings
            this.ToTable("tb_loja");
            this.Property(t => t.cod_loja).HasColumnName("cod_loja");
            this.Property(t => t.loja).HasColumnName("loja");
            this.Property(t => t.CNPJ).HasColumnName("CNPJ");
        }
    }
}