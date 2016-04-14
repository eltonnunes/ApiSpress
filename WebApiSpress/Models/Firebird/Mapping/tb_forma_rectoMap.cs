using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Firebird.Mapping
{
    public class tb_forma_rectoMap : EntityTypeConfiguration<tb_forma_recto>
    {
        public tb_forma_rectoMap()
        {
            // Primary Key
            this.HasKey(t => t.COD_FORMA_RECTO);
            
            // Properties
            this.Property(t => t.COD_FORMA_RECTO)
                .IsRequired();
                
            this.Property(t => t.loja)
                .IsRequired();

            this.Property(t => t.pagamento);
                                
            this.Property(t => t.PGTO_FANTASIA);

            // Table & Column Mappings
            this.ToTable("tb_forma_recto");
            this.Property(t => t.COD_FORMA_RECTO).HasColumnName("COD_FORMA_RECTO");
            this.Property(t => t.loja).HasColumnName("loja");
            this.Property(t => t.pagamento).HasColumnName("pagamento");
            this.Property(t => t.PGTO_FANTASIA).HasColumnName("PGTO_FANTASIA");            
        }
    }
}
