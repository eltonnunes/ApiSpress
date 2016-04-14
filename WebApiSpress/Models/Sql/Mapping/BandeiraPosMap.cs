using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class BandeiraPosMap : EntityTypeConfiguration<BandeiraPos>
    {
        public BandeiraPosMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.desBandeira)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("BandeiraPos", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.desBandeira).HasColumnName("desBandeira");
            this.Property(t => t.idOperadora).HasColumnName("idOperadora");

            // Relationships
            this.HasRequired(t => t.Operadora)
                .WithMany(t => t.BandeiraPos)
                .HasForeignKey(d => d.idOperadora);

        }
    }
}
