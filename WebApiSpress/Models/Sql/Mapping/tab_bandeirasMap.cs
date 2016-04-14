using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tab_bandeirasMap : EntityTypeConfiguration<tab_bandeiras>
    {
        public tab_bandeirasMap()
        {
            // Primary Key
            this.HasKey(t => t.cod_bandeira);

            // Properties
            this.Property(t => t.cod_bandeira)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.desc_bandeira)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("tab_bandeiras");
            this.Property(t => t.cod_bandeira).HasColumnName("cod_bandeira");
            this.Property(t => t.desc_bandeira).HasColumnName("desc_bandeira");
            this.Property(t => t.dth_ultima_at).HasColumnName("dth_ultima_at");
        }
    }
}
