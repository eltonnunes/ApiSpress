using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class convmodoentradaMap : EntityTypeConfiguration<convmodoentrada>
    {
        public convmodoentradaMap()
        {
            // Primary Key
            this.HasKey(t => new { t.cod_sit, t.bit_22 });

            // Properties
            this.Property(t => t.cod_sit)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.bit_22)
                .IsRequired()
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("convmodoentrada");
            this.Property(t => t.cod_sit).HasColumnName("cod_sit");
            this.Property(t => t.bit_22).HasColumnName("bit_22");
            this.Property(t => t.cdmodoentrada).HasColumnName("cdmodoentrada");

            // Relationships
            this.HasRequired(t => t.modoentrada)
                .WithMany(t => t.convmodoentradas)
                .HasForeignKey(d => d.cdmodoentrada);
            this.HasRequired(t => t.sitrede)
                .WithMany(t => t.convmodoentradas)
                .HasForeignKey(d => d.cod_sit);

        }
    }
}
