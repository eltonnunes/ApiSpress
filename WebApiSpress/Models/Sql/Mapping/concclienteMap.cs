using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class concclienteMap : EntityTypeConfiguration<conccliente>
    {
        public concclienteMap()
        {
            // Primary Key
            this.HasKey(t => new { t.cod_sit, t.data_trn, t.nsu_sitef, t.codlojasitef });

            // Properties
            this.Property(t => t.cod_sit)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.data_trn)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.nsu_sitef)
                .IsRequired()
                .HasMaxLength(9);

            this.Property(t => t.codlojasitef)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.codcliente)
                .HasMaxLength(32);

            this.Property(t => t.cuponfiscal)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("concclientes");
            this.Property(t => t.cod_sit).HasColumnName("cod_sit");
            this.Property(t => t.data_trn).HasColumnName("data_trn");
            this.Property(t => t.nsu_sitef).HasColumnName("nsu_sitef");
            this.Property(t => t.codlojasitef).HasColumnName("codlojasitef");
            this.Property(t => t.codcliente).HasColumnName("codcliente");
            this.Property(t => t.cuponfiscal).HasColumnName("cuponfiscal");
            this.Property(t => t.se_cliente).HasColumnName("se_cliente");
        }
    }
}
