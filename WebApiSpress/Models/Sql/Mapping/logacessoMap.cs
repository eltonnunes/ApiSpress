using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class logacessoMap : EntityTypeConfiguration<logacesso>
    {
        public logacessoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.cod_usuario, t.datahora, t.statusacesso });

            // Properties
            this.Property(t => t.cod_usuario)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.datahora)
                .IsRequired()
                .HasMaxLength(14);

            this.Property(t => t.statusacesso)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("logacesso");
            this.Property(t => t.cod_usuario).HasColumnName("cod_usuario");
            this.Property(t => t.datahora).HasColumnName("datahora");
            this.Property(t => t.statusacesso).HasColumnName("statusacesso");
        }
    }
}
