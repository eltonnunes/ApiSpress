using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbProdutoTefMap : EntityTypeConfiguration<tbProdutoTef>
    {
        public tbProdutoTefMap()
        {
            // Primary Key
            this.HasKey(t => t.cdProdutoTef);

            // Properties
            this.Property(t => t.cdProdutoTef)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.dsProdutoTef)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("tbProdutoTef", "card");
            this.Property(t => t.cdProdutoTef).HasColumnName("cdProdutoTef");
            this.Property(t => t.cdTipoProdutoTef).HasColumnName("cdTipoProdutoTef");
            this.Property(t => t.dsProdutoTef).HasColumnName("dsProdutoTef");

            // Relationships
            this.HasOptional(t => t.tbTipoProdutoTef)
                .WithMany(t => t.tbProdutoTefs)
                .HasForeignKey(d => d.cdTipoProdutoTef);

        }
    }
}
