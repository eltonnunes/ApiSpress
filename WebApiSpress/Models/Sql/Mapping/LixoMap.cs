using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class LixoMap : EntityTypeConfiguration<Lixo>
    {
        public LixoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Loja, t.ValorComJuros });

            // Properties
            this.Property(t => t.ValorComJuros)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Lixo");
            this.Property(t => t.Loja).HasColumnName("Loja");
            this.Property(t => t.PDV).HasColumnName("PDV");
            this.Property(t => t.Transacao).HasColumnName("Transacao");
            this.Property(t => t.ValorComJuros).HasColumnName("ValorComJuros");
            this.Property(t => t.ValorSemJuros).HasColumnName("ValorSemJuros");
        }
    }
}
