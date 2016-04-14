using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class modoentradaMap : EntityTypeConfiguration<modoentrada>
    {
        public modoentradaMap()
        {
            // Primary Key
            this.HasKey(t => t.cdmodoentrada);

            // Properties
            this.Property(t => t.cdmodoentrada)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.descr_modoent)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("modoentrada");
            this.Property(t => t.cdmodoentrada).HasColumnName("cdmodoentrada");
            this.Property(t => t.descr_modoent).HasColumnName("descr_modoent");
        }
    }
}
