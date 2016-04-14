using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbIPTefMap : EntityTypeConfiguration<tbIPTef>
    {
        public tbIPTefMap()
        {
            // Primary Key
            this.HasKey(t => t.nrIPTef);

            // Properties
            this.Property(t => t.nrIPTef)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("tbIPTef", "cartao");
            this.Property(t => t.nrIPTef).HasColumnName("nrIPTef");
            this.Property(t => t.cdGrupo).HasColumnName("cdGrupo");
        }
    }
}
