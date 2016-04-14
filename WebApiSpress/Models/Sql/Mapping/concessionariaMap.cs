using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class concessionariaMap : EntityTypeConfiguration<concessionaria>
    {
        public concessionariaMap()
        {
            // Primary Key
            this.HasKey(t => t.cod_concessionaria);

            // Properties
            this.Property(t => t.cod_concessionaria)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.descr_concessionaria)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("concessionaria");
            this.Property(t => t.cod_concessionaria).HasColumnName("cod_concessionaria");
            this.Property(t => t.descr_concessionaria).HasColumnName("descr_concessionaria");

            // Relationships
            this.HasMany(t => t.grp_concessionaria)
                .WithMany(t => t.concessionarias)
                .Map(m =>
                    {
                        m.ToTable("def_grp_concessionaria");
                        m.MapLeftKey("cod_concessionaria");
                        m.MapRightKey("cod_grp_concessionaria");
                    });


        }
    }
}
