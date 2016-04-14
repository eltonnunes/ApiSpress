using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbTipoProdutoTefMap : EntityTypeConfiguration<tbTipoProdutoTef>
    {
        public tbTipoProdutoTefMap()
        {
            // Primary Key
            this.HasKey(t => t.cdTipoProdutoTef);

            // Properties
            this.Property(t => t.cdTipoProdutoTef)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.dsTipoProdutoTef)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("tbTipoProdutoTef", "card");
            this.Property(t => t.cdTipoProdutoTef).HasColumnName("cdTipoProdutoTef");
            this.Property(t => t.dsTipoProdutoTef).HasColumnName("dsTipoProdutoTef");
        }
    }
}
